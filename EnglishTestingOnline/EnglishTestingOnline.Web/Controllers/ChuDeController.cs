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
    public class ChuDeController : Controller
    {
        private IChuDeSercive _chuDeService;
        private ICauhoiService _cauHoiService;
        public ChuDeController(IChuDeSercive chuDeService, ICauhoiService cauHoiService)
        {
            this._chuDeService = chuDeService;
            this._cauHoiService = cauHoiService;
        }
        public ActionResult Index(int keyword, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<ChuDe> model = null;

                model = _chuDeService.GetAllPaging(page, pageSize, out totalRow);

                model = _chuDeService.SearchByName(keyword, page, pageSize, out totalRow);

            var viewModel = Mapper.Map<IEnumerable<ChuDe>, IEnumerable<ChuDeViewModel>>(model);
            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            Session["listChuDe"] = viewModel;
            var paginationSet = new PaginationSet<ChuDeViewModel>()
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
            return View();
        }
        [HttpPost]
        public ActionResult Add(ChuDeViewModel chuDeVM)
        {
            if (ModelState.IsValid)
            {
                var chuDe = new ChuDe();
                chuDe.UpdateChuDe(chuDeVM);
                _chuDeService.Add(chuDe);
                _chuDeService.Save();


                return RedirectToAction("Index");
            }
            return View(chuDeVM);
        }
        public ActionResult Edit(int id)
        {
            var chuDe = _chuDeService.GetById(id);
            var chuDeVM = Mapper.Map<ChuDe, ChuDeViewModel>(chuDe);
            return View(chuDeVM);
        }

        [HttpPost]
        public ActionResult Edit(ChuDeViewModel chuDeVM)
        {
            var chuDe = _chuDeService.GetById(chuDeVM.ID);
            chuDe.UpdateChuDe(chuDeVM);
            _chuDeService.Update(chuDe);
            _chuDeService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _chuDeService.Delete(id);
            _chuDeService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteChuDe(int[] listId)
        {
            foreach (var id in listId)
            {
                _chuDeService.Delete(id);
            }
            _chuDeService.Save();
            return RedirectToAction("Index");
        }
    }
}