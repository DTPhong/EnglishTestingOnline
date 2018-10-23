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
    public class LoaiCauTraLoiTracNghiemController : Controller
    {
        private ILoaiCauTraLoiTracNghiemSercive _loaiCauTraLoiTracNghiemService;
        private ICauTraLoiTracNghiemService _cauTraLoiTracNghiemSercive;

        public LoaiCauTraLoiTracNghiemController(ILoaiCauTraLoiTracNghiemSercive loaiCauTraLoiTracNghiemService, ICauTraLoiTracNghiemService cauTraLoiTracNghiemSercive)
        {
            this._loaiCauTraLoiTracNghiemService = loaiCauTraLoiTracNghiemService;
            this._cauTraLoiTracNghiemSercive = cauTraLoiTracNghiemSercive;
        }

        public ActionResult Index(int keyword, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<LoaiCauTraLoiTracNghiem> model = null;

            model = _loaiCauTraLoiTracNghiemService.GetAllPaging(page, pageSize, out totalRow);

            model = _loaiCauTraLoiTracNghiemService.SearchByName(keyword, page, pageSize, out totalRow);

            var viewModel = Mapper.Map<IEnumerable<LoaiCauTraLoiTracNghiem>, IEnumerable<LoaiCauTraLoiTracNghiemViewModel>>(model);
            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            Session["lisKyThi"] = viewModel;
            var paginationSet = new PaginationSet<LoaiCauTraLoiTracNghiemViewModel>()
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
        public ActionResult Add(LoaiCauTraLoiTracNghiemViewModel loaiCauTraLoiTracNghiemVM)
        {
            if (ModelState.IsValid)
            {
                var loaiCauTraLoiTracNghiem = new LoaiCauTraLoiTracNghiem();
                loaiCauTraLoiTracNghiem.UpdateLoaiCauTraLoiTracNghiem(loaiCauTraLoiTracNghiemVM);
                _loaiCauTraLoiTracNghiemService.Add(loaiCauTraLoiTracNghiem);
                _loaiCauTraLoiTracNghiemService.Save();


                return RedirectToAction("Index");
            }
            return View(loaiCauTraLoiTracNghiemVM);
        }
        public ActionResult Edit(int id)
        {
            var loaiCauTraLoiTracNghiem = _loaiCauTraLoiTracNghiemService.GetById(id);
            var loaiCauTraLoiTracNghiemVM = Mapper.Map<LoaiCauTraLoiTracNghiem, LoaiCauTraLoiTracNghiemViewModel>(loaiCauTraLoiTracNghiem);
            return View(loaiCauTraLoiTracNghiemVM);
        }

        [HttpPost]
        public ActionResult Edit(LoaiCauTraLoiTracNghiemViewModel loaiCauTraLoiTracNghiemVM)
        {
            var loaiCauTraLoiTracNghiem = _loaiCauTraLoiTracNghiemService.GetById(loaiCauTraLoiTracNghiemVM.ID);
            loaiCauTraLoiTracNghiem.UpdateLoaiCauTraLoiTracNghiem(loaiCauTraLoiTracNghiemVM);
            _loaiCauTraLoiTracNghiemService.Update(loaiCauTraLoiTracNghiem);
            _loaiCauTraLoiTracNghiemService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _loaiCauTraLoiTracNghiemService.Delete(id);
            _loaiCauTraLoiTracNghiemService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteLoaiCauTraLoiTracNghiem(int[] listId)
        {
            foreach (var id in listId)
            {
                _loaiCauTraLoiTracNghiemService.Delete(id);
            }
            _loaiCauTraLoiTracNghiemService.Save();
            return RedirectToAction("Index");
        }
    }
}