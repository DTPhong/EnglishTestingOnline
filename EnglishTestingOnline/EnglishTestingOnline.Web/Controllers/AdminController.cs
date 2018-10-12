using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}