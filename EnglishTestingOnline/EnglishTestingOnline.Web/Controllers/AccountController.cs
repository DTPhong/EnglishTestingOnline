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
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }
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
            user.FirstName = appUser.FirstName;
            user.LastName = appUser.LastName;
            user.Password = appUser.PasswordHash;
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
            var currentUser = manager.FindById(model.Id);
            currentUser.LastName = model.LastName;
            currentUser.FirstName = model.FirstName;
            currentUser.PasswordHash = model.Password;
            currentUser.Address = model.Address;
            currentUser.PhoneNumber = model.Phone;
            await manager.UpdateAsync(currentUser);
            TempData["msg"] = "Profile Changes Saved !";
            return RedirectToAction("Index");
        }

    }
}