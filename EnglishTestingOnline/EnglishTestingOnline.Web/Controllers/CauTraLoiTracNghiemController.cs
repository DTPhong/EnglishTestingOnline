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
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace EnglishTestingOnline.Web.Controllers
{
    public class CauTraLoiTracNghiemController : Controller
    {
        private ICauTraLoiTracNghiemService _cauTraLoiTracNghiemService;
        private ICauhoiService _cauHoiService;
        private ILoaiCauTraLoiTracNghiemSercive _loaiCauTraLoiTracNghiemService;
        public CauTraLoiTracNghiemController(ICauTraLoiTracNghiemService cauTraLoiTracNghiemService, ICauhoiService cauHoiService, ILoaiCauTraLoiTracNghiemSercive loaiCauTraLoiTracNghiemService)
        {
            this._cauTraLoiTracNghiemService = cauTraLoiTracNghiemService;
            this._cauHoiService = cauHoiService;
            this._loaiCauTraLoiTracNghiemService = loaiCauTraLoiTracNghiemService;
        }
        public ActionResult Index(string keyword = null, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<CauHoi> model = null;
            if (keyword == "" || keyword == null)
            {
                model = _cauHoiService.GetAllPaging(page, pageSize, out totalRow);
            }
            else
            {
                model = _cauHoiService.SearchByName(keyword, page, pageSize, out totalRow);
            }
            foreach (var item in model)
            {
                var xxx = _cauTraLoiTracNghiemService.GetByCauhoiId(item.ID);
            }
            var viewModel = Mapper.Map<IEnumerable<CauHoi>, IEnumerable<CauHoiViewModel>>(model);
            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            Session["listCauTraLoiTracNghiem"] = viewModel;
            var paginationSet = new PaginationSet<CauHoiViewModel>()
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
            ViewBag.ListCauHoi = _cauHoiService.GetAll();
            ViewBag.ListLoaiCauTraLoiTracNghiem = _loaiCauTraLoiTracNghiemService.GetAll();

            return View();
        }
        [HttpPost]
        public ActionResult Add(CauTraLoiTracNghiemViewModel cauTraLoiTracNghiemVM)
        {
            ViewBag.ListCauHoi = _cauHoiService.GetAll();
            ViewBag.ListLoaiCauTraLoiTracNghiem = _loaiCauTraLoiTracNghiemService.GetAll();
            if (ModelState.IsValid)
            {
                var cauTraLoiTracNghiem = new CauTraLoiTracNghiem();
                cauTraLoiTracNghiem.UpdateCauTraLoiTracNghiem(cauTraLoiTracNghiemVM);
                _cauTraLoiTracNghiemService.Add(cauTraLoiTracNghiem);
                _cauTraLoiTracNghiemService.Save();


                return RedirectToAction("Index");
            }
            return View(cauTraLoiTracNghiemVM);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ListCauHoi = _cauHoiService.GetAll();
            ViewBag.ListLoaiCauTraLoiTracNghiem = _loaiCauTraLoiTracNghiemService.GetAll();
            var cauTraLoiTracNghiem = _cauTraLoiTracNghiemService.GetById(id);
            var cauTraLoiTracNghiemViewModel = Mapper.Map<CauTraLoiTracNghiem, CauTraLoiTracNghiemViewModel>(cauTraLoiTracNghiem);
            return View(cauTraLoiTracNghiemViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CauTraLoiTracNghiemViewModel cauTraLoiTracNghiemVM)
        {
            var cauTraLoiTracNghiem = _cauTraLoiTracNghiemService.GetById(cauTraLoiTracNghiemVM.ID);
            cauTraLoiTracNghiem.UpdateCauTraLoiTracNghiem(cauTraLoiTracNghiemVM);
            _cauTraLoiTracNghiemService.Update(cauTraLoiTracNghiem);
            _cauTraLoiTracNghiemService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _cauTraLoiTracNghiemService.Delete(id);
            _cauTraLoiTracNghiemService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteAnsMulti(int[] listId)
        {
            foreach (var id in listId)
            {
                _cauTraLoiTracNghiemService.Delete(id);
            }
            _cauTraLoiTracNghiemService.Save();
            return RedirectToAction("Index");
        }
    }
}   