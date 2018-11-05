using AutoMapper;
using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Service;
using EnglishTestingOnline.Web.App_Start;
using EnglishTestingOnline.Web.Infrastructure.Core;
using EnglishTestingOnline.Web.Infrastructure.Extensions;
using EnglishTestingOnline.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishTestingOnline.Web.Controllers
{
    public class BaiLamController : Controller
    {
        private IBaiLamService _baiLamService;
        private IDeThiSercive _deThiService;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public BaiLamController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationRoleManager roleManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            RoleManager = roleManager;
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
        public BaiLamController(IBaiLamService baiLamService, ICauTraLoiBaiLamService cauTraLoiBaiLamService, IDeThiSercive deThiService)
        {
            this._baiLamService = baiLamService;
            this._deThiService = deThiService;

        }
        public ActionResult Index(string keyword = null, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<BaiLam> model = null;
            if (keyword == "" || keyword == null)
            {
                model = _baiLamService.GetAllPaging(page, pageSize, out totalRow);
            }
            else
            {
                model = _baiLamService.SearchByName(keyword, page, pageSize, out totalRow);
            }
            var viewModel = Mapper.Map<IEnumerable<BaiLam>, IEnumerable<BaiLamViewModel>>(model);

            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            
            var paginationSet = new PaginationSet<BaiLamViewModel>()
            {
                
                Items = viewModel,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }
        public ActionResult Add()
        {
            //ViewBag.ListCauTraLoiBaiLam = _cauTraLoiBaiLamService.GetAll();
            ViewBag.ListDeThi = _deThiService.GetAll();
            List<SelectListItem> listStudent = new List<SelectListItem>();
            foreach (var item in UserManager.Users)
            {
                listStudent.Add(new SelectListItem() { Value = item.Id, Text = item.AccountName });
            }
            ViewBag.Roles = listStudent;
            return View();
        }
        [HttpPost]
        public ActionResult Add(BaiLamViewModel baiLamVM)
        {
         
            ViewBag.ListDeThi = _deThiService.GetAll();

            if (ModelState.IsValid)
            {
                var baiLam = new BaiLam();
                baiLam.UpdateBaiLam(baiLamVM);
                _baiLamService.Add(baiLam);
                _baiLamService.Save();


                return RedirectToAction("Index");
            }
            return View(baiLamVM);
        }
        public ActionResult Edit(int id)
        {
           
            //ViewBag.ListHocVien = _hocVienService.GetAll();
            ViewBag.ListDeThi = _deThiService.GetAll();
            var baiLam = _baiLamService.GetById(id);
            var baiLamViewModel = Mapper.Map<BaiLam, BaiLamViewModel>(baiLam);
            return View(baiLamViewModel);
        }

        [HttpPost]
        public ActionResult Edit(BaiLamViewModel baiLamVM)
        {
            var baiLam = _baiLamService.GetById(baiLamVM.ID);
            baiLam.UpdateBaiLam(baiLamVM);
            _baiLamService.Update(baiLam);
            _baiLamService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _baiLamService.Delete(id);
            _baiLamService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteBaiLam(int[] listId)
        {
            foreach (var id in listId)
            {
                _baiLamService.Delete(id);
            }
            _baiLamService.Save();
            return RedirectToAction("Index");
        }
    }
}