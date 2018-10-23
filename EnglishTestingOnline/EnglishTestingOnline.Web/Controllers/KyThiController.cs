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
    public class KyThiController : Controller
    {
        private IKyThiSercive _kyThiService;
        private IDeThiSercive _deThiSercive;

        public KyThiController(IKyThiSercive kyThiService, IDeThiSercive deThiSercive)
        {
            this._kyThiService = kyThiService;
            this._deThiSercive = deThiSercive;
        }

        public ActionResult Index(int keyword, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<KyThi> model = null;

            model = _kyThiService.GetAllPaging(page, pageSize, out totalRow);

            model = _kyThiService.SearchByName(keyword, page, pageSize, out totalRow);

            var viewModel = Mapper.Map<IEnumerable<KyThi>, IEnumerable<KyThiViewModel>>(model);
            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            Session["lisKyThi"] = viewModel;
            var paginationSet = new PaginationSet<KyThiViewModel>()
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
        public ActionResult Add(KyThiViewModel kyThiVM)
        {
            if (ModelState.IsValid)
            {
                var kyThi = new KyThi();
                kyThi.UpdateKyThi(kyThiVM);
                _kyThiService.Add(kyThi);
                _kyThiService.Save();


                return RedirectToAction("Index");
            }
            return View(kyThiVM);
        }
        public ActionResult Edit(int id)
        {
            var kyThi = _kyThiService.GetById(id);
            var kyThiVM = Mapper.Map<KyThi, KyThiViewModel>(kyThi);
            return View(kyThiVM);
        }

        [HttpPost]
        public ActionResult Edit(KyThiViewModel kyThiVM)
        {
            var kyThi = _kyThiService.GetById(kyThiVM.ID);
            kyThi.UpdateKyThi(kyThiVM);
            _kyThiService.Update(kyThi);
            _kyThiService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _kyThiService.Delete(id);
            _kyThiService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteKyThi(int[] listId)
        {
            foreach (var id in listId)
            {
                _kyThiService.Delete(id);
            }
            _kyThiService.Save();
            return RedirectToAction("Index");
        }
    }
}