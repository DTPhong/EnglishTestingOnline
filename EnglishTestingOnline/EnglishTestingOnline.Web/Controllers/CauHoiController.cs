using AutoMapper;
using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Service;
using EnglishTestingOnline.Web.Infrastructure.Core;
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
        public CauHoiController(ICauhoiService cauhoiService)
        {
            this._cauHoiService = cauhoiService;
        }
        // GET: CauHoi
        public ActionResult Index()
        {
            var model = _cauHoiService.GetAll();
            var viewModel = Mapper.Map<IEnumerable<CauHoi>, IEnumerable<CauHoiViewModel>>(model);


            //System.Xml.Serialization.XmlSerializer writer =
            //    new System.Xml.Serialization.XmlSerializer(viewModel.GetType());

            //var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//XSLT/listCauHoi.xml";
            //System.IO.FileStream file = System.IO.File.Create(path);

            //writer.Serialize(file, viewModel);
            //file.Close();

            return View(viewModel);
        }

        public ActionResult IndexPaging(int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;

            var model = _cauHoiService.GetAllPaging(page, pageSize, out totalRow);
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
    }
}