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
        public static void UpdateCauTraLoiTracNghiem(this CauTraLoiTracNghiem cauTraLoiTracNghiem, CauTraLoiTracNghiemViewModel cauTraLoiTracNghiemVM)
        {
            cauTraLoiTracNghiem.ID = cauTraLoiTracNghiemVM.ID;
            cauTraLoiTracNghiem.CauHoi_ID = cauTraLoiTracNghiemVM.CauHoi_ID;
            cauTraLoiTracNghiem.LoaiCauTraLoi_ID = cauTraLoiTracNghiemVM.LoaiCauTraLoi_ID;
            cauTraLoiTracNghiem.NoiDung = cauTraLoiTracNghiemVM.NoiDung;

        }
        public static void UpdateBaiDocNghe(this BaiDocNghe baiDocNghe, BaiDocNgheViewModel baiDocNgheVM)
        {
            baiDocNghe.ID = baiDocNgheVM.ID;
            baiDocNghe.LoaiBaiDocNghe_ID = baiDocNgheVM.LoaiBaiDocNghe_ID;
            baiDocNghe.NoiDung = baiDocNgheVM.NoiDung;
        }
        public static void UpdateBaiLam (this BaiLam baiLam, BaiLamViewModel baiLamVM)
        {
            baiLam.ID = baiLamVM.ID;
            baiLam.HocVien_ID = baiLamVM.HocVien_ID;
            baiLam.DeThi_ID = baiLamVM.DeThi_ID;
            baiLam.DiemNghe = baiLamVM.DiemNghe;
            baiLam.DiemNoi = baiLamVM.DiemNoi;
            baiLam.DiemDoc = baiLamVM.DiemDoc;
            baiLam.DiemViet = baiLamVM.DiemViet;
        }
        public static void UpdateCauHoiDeThi (this CauHoiDeThi cauHoiDeThi, CauHoiDeThiViewModel cauHoiDeThiVM)
        {
            cauHoiDeThi.DeThi_ID = cauHoiDeThiVM.DeThi_ID;
            cauHoiDeThi.CauHoi_ID = cauHoiDeThiVM.CauHoi_ID;
        }
    }
}