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
    public class HocVienController : Controller
    {
        private IHocVienSercive _hocVienService;
        private IBaiLamSercive _baiLamSercive;

        public HocVienController(IHocVienSercive hocVienService, IBaiLamSercive baiLamSercive)
        {
            this._hocVienService = hocVienService;
            this._baiLamSercive = baiLamSercive;
        }

        public ActionResult Index(string keyword = null, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<HocVien> model = null;
            if (keyword == "" || keyword == null)
            {
                model = _hocVienService.GetAllPaging(page, pageSize, out totalRow);
            }
            else
            {
                model = _hocVienService.SearchByName(keyword, page, pageSize, out totalRow);
            }
            var viewModel = Mapper.Map<IEnumerable<HocVien>, IEnumerable<HocVienViewModel>>(model);
            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            if (keyword == null)
            {
                Session["listHocVien"] = Mapper.Map<IEnumerable<HocVien>, IEnumerable<HocVienViewModel>>(_hocVienService.GetAll());
            }
            else
            {
                Session["listHocVien"] = viewModel;
            }
            var paginationSet = new PaginationSet<HocVienViewModel>()
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
        public ActionResult Add(HocVienViewModel hocVienVM)
        {
            var hocVien = new HocVien();
            hocVien.UpdateHocVien(hocVienVM);
            _hocVienService.Add(hocVien);
            _hocVienService.Save();


            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var hocVien = _hocVienService.GetById(id);
            var hocVienVM = Mapper.Map<HocVien, HocVienViewModel>(hocVien);
            return View(hocVienVM);
        }

        [HttpPost]
        public ActionResult Edit(HocVienViewModel hocVienVM)
        {
            var hocVien = _hocVienService.GetById(hocVienVM.ID);
            hocVien.UpdateHocVien(hocVienVM);
            _hocVienService.Update(hocVien);
            _hocVienService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _hocVienService.Delete(id);
            _hocVienService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteHocVien(int[] listId)
        {
            foreach (var id in listId)
            {
                _hocVienService.Delete(id);
            }
            _hocVienService.Save();
            return RedirectToAction("Index");
        }
    }
}