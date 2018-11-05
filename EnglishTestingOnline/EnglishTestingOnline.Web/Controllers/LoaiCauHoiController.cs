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
using System.Xml.Serialization;

namespace EnglishTestingOnline.Web.Controllers
{
    public class LoaiCauHoiController : Controller
    {
        private ILoaiCauHoiService _loaiCauHoiService;
        public LoaiCauHoiController(ILoaiCauHoiService loaiCauHoiService)
        {
            this._loaiCauHoiService = loaiCauHoiService;
        }
        // GET: LoaiCauHoi
        public ActionResult Index(string keyword = null, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<LoaiCauHoi> model = null;
            if (keyword == "" || keyword == null)
            {
                model = _loaiCauHoiService.GetAllPaging(page, pageSize, out totalRow);
            }
            else
            {
                model = _loaiCauHoiService.SearchByName(keyword, page, pageSize, out totalRow);
            }
            var viewModel = Mapper.Map<IEnumerable<LoaiCauHoi>, IEnumerable<LoaiCauHoiViewModel>>(model);

            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<LoaiCauHoiViewModel>()
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
        public ActionResult Add(LoaiCauHoiViewModel loaicauHoiVM)
        {
            var loaicauHoi = new LoaiCauHoi();
            loaicauHoi.UpdateLoaiCauHoi(loaicauHoiVM);
            _loaiCauHoiService.Add(loaicauHoi);
            _loaiCauHoiService.Save();


            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
      
            var loaicauHoi = _loaiCauHoiService.GetById(id);
            var loaicauHoiViewModel = Mapper.Map<LoaiCauHoi, LoaiCauHoiViewModel>(loaicauHoi);
            return View(loaicauHoiViewModel);
        }

        [HttpPost]
        public ActionResult Edit(LoaiCauHoiViewModel loaicauHoiVM)
        {
            var loaicauHoi = _loaiCauHoiService.GetById(loaicauHoiVM.ID);
            loaicauHoi.UpdateLoaiCauHoi(loaicauHoiVM);
            _loaiCauHoiService.Update(loaicauHoi);
            _loaiCauHoiService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _loaiCauHoiService.Delete(id);
            _loaiCauHoiService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteTypeAns(int[] listId)
        {
            foreach (var id in listId)
            {
                _loaiCauHoiService.Delete(id);
            }
            _loaiCauHoiService.Save();
            return RedirectToAction("Index");
        }
    }
}