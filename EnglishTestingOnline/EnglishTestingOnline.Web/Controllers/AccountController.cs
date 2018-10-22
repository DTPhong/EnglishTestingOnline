using EnglishTestingOnline.Data;
using EnglishTestingOnline.Web.App_Start;
using EnglishTestingOnline.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EnglishTestingOnline.Web.Controllers
{

    public class AccountController : Controller
    {
        EnglishDbContext db = new EnglishDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationRoleManager roleManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            RoleManager = roleManager;
        }
        public AccountController() { }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public ActionResult Index()
        {
            IEnumerable<ApplicationUser> model = UserManager.Users;
            return View(model);
        }
        //[HttpGet]
        //public async Task<IActionResult> EditUser(string id)
        //{
        //    EditUserViewModel model = new EditUserViewModel();
        //    model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
        //    {
        //        Text = r.Name,
        //        Value = r.Id
        //    }).ToList();



        //    if (!String.IsNullOrEmpty(id))
        //    {
        //        ApplicationUser user = await userManager.FindByIdAsync(id);
        //        if (user != null)
        //        {
        //            model.Name = user.Name;
        //            model.Email = user.Email;
        //            model.ApplicationRoleId = RoleManager.Roles.Single(r => r.Name == UserManager.GetRoles(id).Single()).Id; // Here crashing .. I don't know why.. Server 500 error
        //            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name", model.ApplicationRoleId);
        //        }
        //    }
        //    return PartialView("_EditUser", model);
        //}

        public ActionResult EditUser(string id)
        {
            ApplicationUser appUser = new ApplicationUser();
            appUser = UserManager.FindById(id);
            EditUserViewModel user = new EditUserViewModel();
            user.Phone = appUser.PhoneNumber;
            user.Email = appUser.Email;
            user.UserName = appUser.AccountName;
            user.Address = appUser.Address;
            var oldUser = db.Users.SingleOrDefault(u => u.Id == id);
            var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
            var oldRoleName = db.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
            user.RoleName = oldRoleName;
            List<SelectListItem> listRole = new List<SelectListItem>();
            foreach (var item in RoleManager.Roles)
            {
                listRole.Add(new SelectListItem() { Value = item.Name, Text = item.Name });
            }
            ViewBag.Roles = listRole;
            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> EditUser(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var store = new UserStore<ApplicationUser>(new EnglishDbContext());
            var manager = new UserManager<ApplicationUser>(store);

            //Update User Role
            var oldUser = db.Users.SingleOrDefault(u => u.Id == model.Id);
            var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
            var oldRoleName = db.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
            if (!string.IsNullOrEmpty(model.RoleName))
                if (oldRoleName != model.RoleName)
                {
                    manager.RemoveFromRole(model.Id, oldRoleName);
                    manager.AddToRole(model.Id, model.RoleName);
                }
            //Update User information
            var currentUser = manager.FindById(model.Id);
            currentUser.AccountName = model.UserName;
            currentUser.Address = model.Address;
            currentUser.PhoneNumber = model.Phone;

            //Update User Password
            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                currentUser.PasswordHash = manager.PasswordHasher.HashPassword(model.NewPassword);
            }
            var result = await manager.UpdateAsync(currentUser);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            AddErrors(result);

            return View();
        }
        public ActionResult CreateNewUser()
        {


            List<SelectListItem> listRole = new List<SelectListItem>();
            foreach (var item 
                in RoleManager.Roles)
            {
                listRole.Add(new SelectListItem() { Value = item.Name, Text = item.Name });
            }
            ViewBag.Roles = listRole;
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNewUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    AccountName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    Address = model.Address,
                };
                if (model.Role == null)
                {
                    return View(model);
                }
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user.Id, model.Role);
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    //ViewBag.ThongBao = "Chúng tôi đã gửi 1 email để xác thực tài khoản đến email bạn đã đăng ký. Vui lòng kiểm tra email";
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            List<SelectListItem> listRole = new List<SelectListItem>();
            foreach (var item
                in RoleManager.Roles)
            {
                listRole.Add(new SelectListItem() { Value = item.Name, Text = item.Name });
            }
            ViewBag.Roles = listRole;
            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult UserRegister()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserRegister(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    //ViewBag.ThongBao = "Chúng tôi đã gửi 1 email để xác thực tài khoản đến email bạn đã đăng ký. Vui lòng kiểm tra email";
                    //return View(model);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        public ActionResult UserLogin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> UserLogin(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //OnlineShopEntities db = new OnlineShopEntities();
            //AspNetUser user = db.AspNetUsers.SingleOrDefault(m => m.Email == model.Email);
            //if (user == null)
            //{
            //    ModelState.AddModelError("CustomError", "Email không tồn tại");
            //    return View(model);
            //}
            //else
            //{
            //    if (user.EmailConfirmed == false)
            //    {
            //        ModelState.AddModelError("CustomError", "Tài khoản chưa được xác thực.");
            //        return View(model);
            //    }
            //}

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}