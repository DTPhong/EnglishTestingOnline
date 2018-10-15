using EnglishTestingOnline.Data;
using EnglishTestingOnline.Web.App_Start;
using EnglishTestingOnline.Web.Models;
using Microsoft.AspNet.Identity;
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

      public ActionResult Index()
        {

            return View();
        }


    }
}