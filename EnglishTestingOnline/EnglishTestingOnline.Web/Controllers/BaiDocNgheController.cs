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
    public class BaiDocNgheController : Controller
    {
        private IBaiDocNgheService _baiDocNgheService;
        private ICauhoiService _cauHoiService;
        private ILoaiBaiDocNgheService _loaiBaiDocNgheService;
        public BaiDocNgheController(IBaiDocNgheService baiDocNgheService, ICauhoiService cauHoiService, ILoaiBaiDocNgheService loaiBaiDocNgheService)
        {
            this._baiDocNgheService = baiDocNgheService;
            this._cauHoiService = cauHoiService;
            this._loaiBaiDocNgheService = loaiBaiDocNgheService;
        }
        public ActionResult Index(string keyword = null, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<BaiDocNghe> model = null;
            if (keyword == "" || keyword == null)
            {
                model = _baiDocNgheService.GetAllPaging(page, pageSize, out totalRow);
            }
            else
            {
                model = _baiDocNgheService.SearchByName(keyword, page, pageSize, out totalRow);
            }
            var viewModel = Mapper.Map<IEnumerable<BaiDocNghe>, IEnumerable<BaiDocNgheViewModel>>(model);

            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<BaiDocNgheViewModel>()
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
            ViewBag.ListLoaiBaiDocNghe = _loaiBaiDocNgheService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Add(BaiDocNgheViewModel baiDocNgheVM)
        {
            var baiDocNghe = new BaiDocNghe();
            baiDocNghe.UpdateBaiDocNghe(baiDocNgheVM);
            _baiDocNgheService.Add(baiDocNghe);
            _baiDocNgheService.Save();


            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ListLoaiBaiDocNghe = _loaiBaiDocNgheService.GetAll();
            var baiDocNghe = _baiDocNgheService.GetById(id);
            var baiDocNgheViewModel = Mapper.Map<BaiDocNghe, BaiDocNgheViewModel>(baiDocNghe);
            return View(baiDocNgheViewModel);
        }

        [HttpPost]
        public ActionResult Edit(BaiDocNgheViewModel baiDocNgheVM)
        {
            var baiDocNghe = _baiDocNgheService.GetById(baiDocNgheVM.ID);
            baiDocNghe.UpdateBaiDocNghe(baiDocNgheVM);
            _baiDocNgheService.Update(baiDocNghe);
            _baiDocNgheService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _baiDocNgheService.Delete(id);
            _baiDocNgheService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteBaiDocNghe(int[] listId)
        {
            foreach (var id in listId)
            {
                _baiDocNgheService.Delete(id);
            }
            _baiDocNgheService.Save();
            return RedirectToAction("Index");
        }
    }
}