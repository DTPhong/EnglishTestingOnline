using AutoMapper;
using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Service;
using EnglishTestingOnline.Web.Infrastructure.Core;
using EnglishTestingOnline.Web.Infrastructure.Extensions;
using EnglishTestingOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishTestingOnline.Web.Controllers
{
    public class BaiLamController : Controller
    {
        private IBaiLamSercive _baiLamService;
        private ICauTraLoiBaiLamService _cauTraLoiBaiLamService;
        private IHocVienSercive _hocVienService;
        private IDeThiSercive _deThiService;
        public BaiLamController(IBaiLamSercive baiLamService, ICauTraLoiBaiLamService cauTraLoiBaiLamService)
        {
            this._baiLamService = baiLamService;
            
        }
        public ActionResult Index(int keyword, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<BaiLam> model = null;

                model = _baiLamService.SearchByName(keyword, page, pageSize, out totalRow);

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
            ViewBag.ListCauTraLoiBaiLam = _cauTraLoiBaiLamService.GetAll();
            ViewBag.ListHocVien = _hocVienService.GetAll();
            ViewBag.ListDeThi = _deThiService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Add(BaiLamViewModel baiLamVM)
        {
            ViewBag.ListCauTraLoiBaiLam = _cauTraLoiBaiLamService.GetAll();
            ViewBag.ListHocVien = _hocVienService.GetAll();
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
            ViewBag.ListCauTraLoiBaiLam = _cauTraLoiBaiLamService.GetAll();
            ViewBag.ListHocVien = _hocVienService.GetAll();
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