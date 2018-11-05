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
    public class DeThiController : Controller
    {
        private IDeThiSercive _deThiService;
        private IKyThiSercive _kyThiService;
        private ICauHoiDeThiService _cauHoiDeThiSercive;
        private IBaiLamService _baiLamService;

        public DeThiController(IDeThiSercive deThiService, IKyThiSercive kyThiService, ICauHoiDeThiService cauHoiDeThiSercive, IBaiLamService baiLamService)
        {
            this._deThiService = deThiService;
            this._kyThiService = kyThiService;
            this._cauHoiDeThiSercive = cauHoiDeThiSercive;
            this._baiLamService = baiLamService;
        }

        public ActionResult Index(int keyword, int page = 1)
        {
            //tổng record 1 page
            int pageSize = 20;
            //lấy từ record 0
            int totalRow = 0;
            IEnumerable<DeThi> model = null;

            model = _deThiService.GetAllPaging(page, pageSize, out totalRow);

            model = _deThiService.SearchByName(keyword, page, pageSize, out totalRow);

            var viewModel = Mapper.Map<IEnumerable<DeThi>, IEnumerable<DeThiViewModel>>(model);
            // tổng số page
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            Session["listDeThi"] = viewModel;
            var paginationSet = new PaginationSet<DeThiViewModel>()
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
            ViewBag.ListDeThi = _deThiService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Add(DeThiViewModel deThiVM)
        {
            ViewBag.ListDeThi = _deThiService.GetAll();
            if (ModelState.IsValid)
            {
                var deThi = new DeThi();
                deThi.UpdateDeThi(deThiVM);
                _deThiService.Add(deThi);
                _deThiService.Save();


                return RedirectToAction("Index");
            }
            return View(deThiVM);
        }
        public ActionResult Edit(int id)
        {
            var deThi = _deThiService.GetById(id);
            var deThiVM = Mapper.Map<DeThi, DeThiViewModel>(deThi);
            return View(deThiVM);
        }

        [HttpPost]
        public ActionResult Edit(DeThiViewModel deThiVM)
        {
            var deThi = _deThiService.GetById(deThiVM.ID);
            deThi.UpdateDeThi(deThiVM);
            _deThiService.Update(deThi);
            _deThiService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _deThiService.Delete(id);
            _deThiService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteDeThi(int[] listId)
        {
            foreach (var id in listId)
            {
                _deThiService.Delete(id);
            }
            _deThiService.Save();
            return RedirectToAction("Index");
        }
    }
}