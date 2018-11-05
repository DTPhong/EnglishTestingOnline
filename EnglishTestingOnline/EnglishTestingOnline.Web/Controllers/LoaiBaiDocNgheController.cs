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
    public class LoaiBaiDocNgheController : Controller
    {
        private ILoaiBaiDocNgheService _loaiBaiDocNgheService;
        private IBaiDocNgheService _baiDocNgheSercive;

        public LoaiBaiDocNgheController(ILoaiBaiDocNgheService loaiBaiDocNgheService, IBaiDocNgheService baiDocNgheSercive)
        {
            this._loaiBaiDocNgheService = loaiBaiDocNgheService;
            this._baiDocNgheSercive = baiDocNgheSercive;
        }

        public ActionResult Index(int keyword, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<LoaiBaiDocNghe> model = null;

            model = _loaiBaiDocNgheService.GetAllPaging(page, pageSize, out totalRow);

            model = _loaiBaiDocNgheService.SearchByName(keyword, page, pageSize, out totalRow);

            var viewModel = Mapper.Map<IEnumerable<LoaiBaiDocNghe>, IEnumerable<LoaiBaiDocNgheViewModel>>(model);
            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            Session["lisLoaiBaiDocNghe"] = viewModel;
            var paginationSet = new PaginationSet<LoaiBaiDocNgheViewModel>()
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
        public ActionResult Add(LoaiBaiDocNgheViewModel loaiBaiDocNgheVM)
        {
            if (ModelState.IsValid)
            {
                var loaiBaiDocNghe = new LoaiBaiDocNghe();
                loaiBaiDocNghe.UpdateLoaiBaiDocNghe(loaiBaiDocNgheVM);
                _loaiBaiDocNgheService.Add(loaiBaiDocNghe);
                _loaiBaiDocNgheService.Save();


                return RedirectToAction("Index");
            }
            return View(loaiBaiDocNgheVM);
        }
        public ActionResult Edit(int id)
        {
            var loaiBaiDocNghe = _loaiBaiDocNgheService.GetById(id);
            var loaiBaiDocNgheVM = Mapper.Map<LoaiBaiDocNghe, LoaiBaiDocNgheViewModel>(loaiBaiDocNghe);
            return View(loaiBaiDocNgheVM);
        }

        [HttpPost]
        public ActionResult Edit(LoaiBaiDocNgheViewModel loaiBaiDocNgheVM)
        {
            var loaiBaiDocNghe = _loaiBaiDocNgheService.GetById(loaiBaiDocNgheVM.ID);
            loaiBaiDocNghe.UpdateLoaiBaiDocNghe(loaiBaiDocNgheVM);
            _loaiBaiDocNgheService.Update(loaiBaiDocNghe);
            _loaiBaiDocNgheService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _loaiBaiDocNgheService.Delete(id);
            _loaiBaiDocNgheService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteLoaiBaiDocNghe(int[] listId)
        {
            foreach (var id in listId)
            {
                _loaiBaiDocNgheService.Delete(id);
            }
            _loaiBaiDocNgheService.Save();
            return RedirectToAction("Index");
        }
    }
}