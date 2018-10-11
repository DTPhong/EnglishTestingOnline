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
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

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
            int pageSize = 20;
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
            Session["listCauHoi"] = viewModel;
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

        public ActionResult Edit(int id)
        {
            ViewBag.ListChuDe = _chuDeService.GetAll();
            ViewBag.ListBaiDocNghe = _baiDocNgheSercive.GetAll();
            ViewBag.ListLoaiCauHoi = _loaiCauHoiService.GetAll();
            var cauHoi = _cauHoiService.GetById(id);
            var cauHoiViewModel = Mapper.Map<CauHoi, CauHoiViewModel>(cauHoi);
            return View(cauHoiViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CauHoiViewModel cauHoiVM)
        {
            var cauHoi = _cauHoiService.GetById(cauHoiVM.ID);
            cauHoi.UpdateCauHoi(cauHoiVM);
            _cauHoiService.Update(cauHoi);
            _cauHoiService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _cauHoiService.Delete(id);
            _cauHoiService.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Export()
        {
            try
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                worksheet.Cells[1, 1] = "Loại câu hỏi";
                worksheet.Cells[1, 2] = "ID bài đọc";
                worksheet.Cells[1, 3] = "Chủ đề";
                worksheet.Cells[1, 4] = "Nội dung câu hỏi";
                worksheet.Cells[1, 5] = "Đáp án";
                int row = 2;
                foreach (CauHoiViewModel c in (IEnumerable<CauHoiViewModel>)Session["listCauHoi"])
                {
                    worksheet.Cells[row, 1] = c.LoaiCauHoi.NoiDung;
                    worksheet.Cells[row, 2] = c.BaiDocNghe_ID;
                    worksheet.Cells[row, 3] = c.ChuDe.TenChuDe;
                    worksheet.Cells[row, 4] = c.NoiDung;
                    worksheet.Cells[row, 5] = c.DapAn; ;
                    row++;
                }

                //format
                worksheet.get_Range("A1", "F1").EntireColumn.AutoFit();

                //format heading
                var range_heading = worksheet.get_Range("A1", "F1");
                range_heading.Font.Bold = true;
                range_heading.Font.Color = System.Drawing.Color.Red;
                range_heading.Font.Size = 13;

               

                workbook.SaveAs("d:\\test\\myproduct.xls");
                workbook.Close();
                Marshal.ReleaseComObject(workbook);
                application.Quit();
                Marshal.FinalReleaseComObject(application);
                ViewBag.Result = "DOne";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
        }

    }
}