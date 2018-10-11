using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Infrastructure.Extensions
{
    public static class EntitiyExtension
    {
        public static void UpdateCauHoi(this CauHoi cauHoi, CauHoiViewModel cauHoiVM)
        {
            cauHoi.ID = cauHoiVM.ID;
            cauHoi.LoaiCauHoi_ID = cauHoiVM.LoaiCauHoi_ID;
            cauHoi.BaiDocNghe_ID = cauHoiVM.BaiDocNghe_ID;
            cauHoi.ChuDe_ID = cauHoiVM.ChuDe_ID;
            cauHoi.NoiDung = cauHoiVM.NoiDung;
            cauHoi.DapAn = cauHoiVM.DapAn;
        }
        public static void UpdateLoaiCauHoi(this LoaiCauHoi loaicauHoi, LoaiCauHoiViewModel loaicauHoiVM)
        {
            loaicauHoi.ID = loaicauHoiVM.ID;
            loaicauHoi.NoiDung = loaicauHoiVM.NoiDung;
  
        }
    }
}