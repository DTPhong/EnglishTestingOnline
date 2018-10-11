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
    public class CauHoiController : Controller
    {
        private ICauhoiService _cauHoiService;
        private IChuDeSercive _chuDeService;
        private IBaiDocNgheSercive _baiDocNgheSercive;
        private ILoaiCauHoiSercive _loaiCauHoiService;
        public CauHoiController(ICauhoiService cauhoiService, IChuDeSercive chuDeService, IBaiDocNgheSercive baiDocNgheSercive, ILoaiCauHoiSercive loaiCauHoiService)
        {
            this._cauHoiService = cauhoiService;
            this._chuDeService = chuDeService;
            this._baiDocNgheSercive = baiDocNgheSercive;
            this._loaiCauHoiService = loaiCauHoiService;
        }
        public ActionResult Index(string keyword = null, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 5;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<CauHoi> model = null;
            if (keyword=="" || keyword==null)
            {
                model = _cauHoiService.GetAllPaging(page, pageSize, out totalRow);
            }
            else
            {
                model = _cauHoiService.SearchByName(keyword, page, pageSize, out totalRow);
            }
            var viewModel = Mapper.Map<IEnumerable<CauHoi>, IEnumerable<CauHoiViewModel>>(model);

            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

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

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Search(string keyword, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;

            var model = _cauHoiService.SearchByName(keyword, page, pageSize, out totalRow);
            var viewModel = Mapper.Map<IEnumerable<CauHoi>, IEnumerable<CauHoiViewModel>>(model);

            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

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
            ViewBag.ListChuDe = _chuDeService.GetAll();
            ViewBag.ListBaiDocNghe = _baiDocNgheSercive.GetAll();
            ViewBag.ListLoaiCauHoi = _loaiCauHoiService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Add(CauHoiViewModel cauHoiVM)
        {
            var cauHoi = new CauHoi();
            cauHoi.UpdateCauHoi(cauHoiVM);
            _cauHoiService.Add(cauHoi);
            _cauHoiService.Save();


            return RedirectToAction("Index");
        }

    }
}