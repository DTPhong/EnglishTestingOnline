using AutoMapper;
using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Service;
using EnglishTestingOnline.Web.Infrastructure.Core;
using EnglishTestingOnline.Web.Infrastructure.Extensions;
using EnglishTestingOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

namespace EnglishTestingOnline.Web.Controllers
{

    public class CauHoiController : Controller
    {
        private ICauhoiService _cauHoiService;
        private IChuDeSercive _chuDeService;
        private IBaiDocNgheService _baiDocNgheService;
        private ILoaiCauHoiService _loaiCauHoiService;

        public CauHoiController(ICauhoiService cauhoiService, IChuDeSercive chuDeService, IBaiDocNgheService baiDocNgheSercive, ILoaiCauHoiService loaiCauHoiService)
        {
            this._cauHoiService = cauhoiService;
            this._chuDeService = chuDeService;
            this._baiDocNgheService = baiDocNgheSercive;
            this._loaiCauHoiService = loaiCauHoiService;
        }
       
        public ActionResult Index(string keyword = null, int page = 1)
        {
                //tổng record 1 page
                int pageSize = 20;
                //lấy từ record 0
                int totalRow = 0;
                IEnumerable<CauHoi> model = null;
                if (keyword == "" || keyword == null)
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
                if (keyword == null)
                {
                    Session["listCauHoi"] = Mapper.Map<IEnumerable<CauHoi>, IEnumerable<CauHoiViewModel>>(_cauHoiService.GetAll());
                }
                else
                {
                    Session["listCauHoi"] = viewModel;
                }
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
          
           
        

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.ListChuDe = _chuDeService.GetAll();
            ViewBag.ListBaiDocNghe = _baiDocNgheService.GetAll();
            ViewBag.ListLoaiCauHoi = _loaiCauHoiService.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Add(CauHoiViewModel cauHoiVM)
        {
            ViewBag.ListChuDe = _chuDeService.GetAll();
            ViewBag.ListBaiDocNghe = _baiDocNgheService.GetAll();
            ViewBag.ListLoaiCauHoi = _loaiCauHoiService.GetAll();
            if (ModelState.IsValid)
            {
                var cauHoi = new CauHoi();
                cauHoi.UpdateCauHoi(cauHoiVM);
                _cauHoiService.Add(cauHoi);
                _cauHoiService.Save();

                TempData["message"] = "Thêm mới câu hỏi thành công.";
                return RedirectToAction("Index");
            }
            return View(cauHoiVM);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.ListChuDe = _chuDeService.GetAll();
            ViewBag.ListBaiDocNghe = _baiDocNgheService.GetAll();
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
            TempData["message"] = "Sửa câu hỏi thành công.";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _cauHoiService.Delete(id);
            _cauHoiService.Save();
            TempData["message"] = "Xoá câu hỏi " + id + " thành công.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteMulti(int[] listId)
        {
            if (listId != null)
            {
                foreach (var id in listId)
                {
                    _cauHoiService.Delete(id);
                }
                _cauHoiService.Save();
                TempData["message"] = "Xoá nhiều record thành công.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Không có record để xoá.";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Export()
        {
            try
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                worksheet.Cells[1, 1] = "Loại câu hỏi";
                worksheet.Cells[1, 2] = "Bài đọc";
                worksheet.Cells[1, 3] = "Chủ đề";
                worksheet.Cells[1, 4] = "Nội dung câu hỏi";
                worksheet.Cells[1, 5] = "Đáp án";
                int row = 2;
                foreach (CauHoiViewModel c in (IEnumerable<CauHoiViewModel>)Session["listCauHoi"])
                {
                    worksheet.Cells[row, 1] = c.LoaiCauHoi.NoiDung;
                    worksheet.Cells[row, 2] = c.BaiDocNghe.NoiDung;
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

                workbook.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\export.xlsx");
                workbook.Close();
                Marshal.ReleaseComObject(workbook);
                application.Quit();
                Marshal.FinalReleaseComObject(application);
                TempData["message"] = "Xuất file dữ liệu ra desktop thành công.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["error"] = "Xuất file dữ liệu ra desktop không thành công.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            if (excelfile == null || excelfile.ContentLength == 0)
            {
                TempData["error"] = "Please select an excel file";
                return RedirectToAction("Index");
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Assets/" + excelfile.FileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    excelfile.SaveAs(path);
                    //read data from excel file
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<CauHoi> listCauHois = new List<CauHoi>();
                    for (int row = 5; row < range.Rows.Count; row++)
                    {
                        CauHoi c = new CauHoi();
                        c.LoaiCauHoi_ID = Convert.ToInt32(((Excel.Range)range.Cells[row, 1]).Text);
                        c.BaiDocNghe_ID = Convert.ToInt32(((Excel.Range)range.Cells[row, 2]).Text);
                        c.ChuDe_ID = Convert.ToInt32(((Excel.Range)range.Cells[row, 3]).Text);
                        c.NoiDung = ((Excel.Range)range.Cells[row, 4]).Text;
                        c.DapAn = ((Excel.Range)range.Cells[row, 5]).Text;
                        _cauHoiService.Add(c);
                    }

                    Marshal.ReleaseComObject(range);
                    Marshal.ReleaseComObject(worksheet);
                    workbook.Close();
                    Marshal.ReleaseComObject(workbook);
                    application.Quit();
                    Marshal.ReleaseComObject(application);

                    _cauHoiService.Save();
                    TempData["message"] = "Nhập file dữ liệu vào database thành công";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Nhập file dữ liệu vào database không thành công";
                    return RedirectToAction("Index");
                }
            }
        }
    }
}