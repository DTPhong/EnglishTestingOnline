using AutoMapper;
using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Service;
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
            return View(viewModel);
        }

        //public void write()
        //{


        //    System.Xml.Serialization.XmlSerializer writer =
        //        new System.Xml.Serialization.XmlSerializer(viewModel.GetType());

        //    var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
        //    System.IO.FileStream file = System.IO.File.Create(path);

        //    writer.Serialize(file, viewModel);
        //    file.Close();
        //}

    }
}