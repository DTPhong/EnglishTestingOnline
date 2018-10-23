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
    public class CauHoiDeThiController : Controller
    {
        private ICauHoiDeThiService _cauHoiDeThiService;
        private IDeThiSercive _deThiService;
        private ICauhoiService _cauHoiService;
        public CauHoiDeThiController(ICauHoiDeThiService cauHoiDeThiService, IDeThiSercive deThiService, ICauhoiService cauHoiService)
        {
            this._cauHoiDeThiService = cauHoiDeThiService;
            this._deThiService = deThiService;
            this._cauHoiDeThiService = cauHoiDeThiService;
        }
        public ActionResult Index(int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<CauHoiDeThi> model = null;
                model = _cauHoiDeThiService.GetAllPaging(page, pageSize, out totalRow);

            
            var viewModel = Mapper.Map<IEnumerable<CauHoiDeThi>, IEnumerable<CauHoiDeThiViewModel>>(model);
            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            Session["listCauTraLoiTracNghiem"] = viewModel;
            var paginationSet = new PaginationSet<CauHoiDeThiViewModel>()
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
            ViewBag.ListDethi = _deThiService.GetAll();
            ViewBag.ListCauHoi = _cauHoiService.GetAll();

            return View();
        }
        [HttpPost]
        public ActionResult Add(CauHoiDeThiViewModel cauHoiDeThiVM)
        {
            ViewBag.ListDethi = _deThiService.GetAll();
            ViewBag.ListCauHoi = _cauHoiService.GetAll();
            if (ModelState.IsValid)
            {
                var cauHoiDeThi = new CauHoiDeThi();
                cauHoiDeThi.UpdateCauHoiDeThi(cauHoiDeThiVM);
                _cauHoiDeThiService.Add(cauHoiDeThi);
                _cauHoiDeThiService.Save();


                return RedirectToAction("Index");
            }
            return View(cauHoiDeThiVM);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ListDethi = _deThiService.GetAll();
            ViewBag.ListCauHoi = _cauHoiService.GetAll();
            var cauHoiDeThi = _cauHoiDeThiService.GetById(id);
            var cauHoiDeThiViewModel = Mapper.Map<CauHoiDeThi, CauHoiDeThiViewModel>(cauHoiDeThi);
            return View(cauHoiDeThiViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CauHoiDeThiViewModel cauHoiDeThiVM)
        {
            var cauHoiDeThi = _cauHoiDeThiService.GetById(cauHoiDeThiVM.DeThi_ID);
            cauHoiDeThi.UpdateCauHoiDeThi(cauHoiDeThiVM);
            _cauHoiDeThiService.Update(cauHoiDeThi);
            _cauHoiDeThiService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _cauHoiDeThiService.Delete(id);
            _cauHoiDeThiService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteQuesExam(int[] listId)
        {
            foreach (var id in listId)
            {
                _cauHoiDeThiService.Delete(id);
            }
            _cauHoiDeThiService.Save();
            return RedirectToAction("Index");
        }
    }
}