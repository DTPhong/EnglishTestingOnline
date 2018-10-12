using EnglishTestingOnline.Web.App_Start;
using EnglishTestingOnline.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EnglishTestingOnline.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sidebar()
        {
            return View();
        }

        public ActionResult Navigation()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }

        public ActionResult SettingButton()
        {
            return View();
        }
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        // GET: Home
  
        public AdminController() { }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
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

        //
        // GET: /Account/VerifyCode
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
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "CauHoi");
        }
    }
}