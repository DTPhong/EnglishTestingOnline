using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Web.App_Start;
using EnglishTestingOnline.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EnglishTestingOnline.Web.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;
        public RoleController()
        {

        }

        public RoleController( ApplicationRoleManager roleManager)
        {
        
            RoleManager = roleManager;
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
        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> listRole = new List<RoleViewModel>();
            foreach(var item in RoleManager.Roles)
            {
                listRole.Add(new RoleViewModel(item));
            }

            return View(listRole);
        }
        public ActionResult CreateUserRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateUserRole(RoleViewModel model)
        {
            var role = new ApplicationRole() { Name = model.Name };
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<ActionResult> Delete(string id)
        //{
        //    await RoleManager.CreateAsync(role);
        //    return RedirectToAction("Index");
        //}
    }
}