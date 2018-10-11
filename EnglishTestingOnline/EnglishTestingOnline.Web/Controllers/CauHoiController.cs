using AutoMapper;
using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Service;
using EnglishTestingOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View(viewModel);
        }

    }
}