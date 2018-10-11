using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class CauHoiViewModel
    {
        public int ID { get; set; }
        public int LoaiCauHoi_ID { get; set; }
        public int? BaiDocNghe_ID { get; set; }
        public int ChuDe_ID { get; set; }
        public string NoiDung { get; set; }
        public string DapAn { get; set; }
        public virtual LoaiCauHoiViewModel LoaiCauHoi { get; set; }
        public virtual BaiDocNgheViewModel BaiDocNghe { get; set; }
        public virtual ChuDeViewModel ChuDe { get; set; }
    }
}