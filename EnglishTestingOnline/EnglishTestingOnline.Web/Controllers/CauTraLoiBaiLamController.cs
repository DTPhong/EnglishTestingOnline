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
    public class CauTraLoiBaiLamController : Controller
    {
        private ICauTraLoiBaiLamService _cauTraLoiBaiLamService;
        private IBaiLamService _baiLamService;
        private ICauhoiService _cauHoiService;
        public CauTraLoiBaiLamController(ICauTraLoiBaiLamService cauTraLoiBaiLamService, IBaiLamService baiLamService, ICauhoiService cauHoiService)
        {
            this._cauTraLoiBaiLamService = cauTraLoiBaiLamService;
            this._baiLamService = baiLamService;
            this._cauHoiService = cauHoiService;
        }
        public ActionResult Index(int keyword, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<CauTraLoiBaiLam> model = null;

            model = _cauTraLoiBaiLamService.GetAllPaging(page, pageSize, out totalRow);

            model = _cauTraLoiBaiLamService.SearchByName(keyword, page, pageSize, out totalRow);

            var viewModel = Mapper.Map<IEnumerable<CauTraLoiBaiLam>, IEnumerable<CauTraLoiBaiLamViewModel>>(model);
            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            Session["listChuDe"] = viewModel;
            var paginationSet = new PaginationSet<CauTraLoiBaiLamViewModel>()
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
            ViewBag.ListBaiLam = _baiLamService.GetAll();
            ViewBag.ListCauHoi = _cauHoiService.GetAll();

            return View();
        }
        [HttpPost]
        public ActionResult Add(CauTraLoiBaiLamViewModel cauTraLoiBaiLamVM)
        {
            ViewBag.ListBaiLam = _baiLamService.GetAll();
            ViewBag.ListCauHoi = _cauHoiService.GetAll();
            if (ModelState.IsValid)
            {
                var cauTraLoiBaiLam = new CauTraLoiBaiLam();
                cauTraLoiBaiLam.UpdateCauTraLoiBaiLam(cauTraLoiBaiLamVM);
                _cauTraLoiBaiLamService.Add(cauTraLoiBaiLam);
                _cauTraLoiBaiLamService.Save();


                return RedirectToAction("Index");
            }
            return View(cauTraLoiBaiLamVM);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ListBaiLam = _baiLamService.GetAll();
            ViewBag.ListCauHoi = _cauHoiService.GetAll();
            var cauTraLoiBaiLam = _cauTraLoiBaiLamService.GetById(id);
            var cauTraLoiBaiLamVM = Mapper.Map<CauTraLoiBaiLam, CauTraLoiBaiLamViewModel>(cauTraLoiBaiLam);
            return View(cauTraLoiBaiLamVM);
        }

        [HttpPost]
        public ActionResult Edit(CauTraLoiBaiLamViewModel cauTraLoiBaiLamVM)
        {
            var cauTraLoiBaiLam = _cauTraLoiBaiLamService.GetById(cauTraLoiBaiLamVM.BaiLam_ID);
            cauTraLoiBaiLam.UpdateCauTraLoiBaiLam(cauTraLoiBaiLamVM);
            _cauTraLoiBaiLamService.Update(cauTraLoiBaiLam);
            _cauTraLoiBaiLamService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _cauTraLoiBaiLamService.Delete(id);
            _cauTraLoiBaiLamService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteCauTLBL(int[] listId)
        {
            foreach (var id in listId)
            {
                _cauTraLoiBaiLamService.Delete(id);
            }
            _cauTraLoiBaiLamService.Save();
            return RedirectToAction("Index");
        }
    }
}