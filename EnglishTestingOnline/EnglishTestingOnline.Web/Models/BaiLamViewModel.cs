using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class BaiLamViewModel
    {
       
        public int ID { get; set; }

        public int HocVien_ID { get; set; }

        public int DeThi_ID { get; set; }
        public float? DiemNghe { get; set; }
        public float? DiemNoi { get; set; }
        public float? DiemDoc { get; set; }
        public float? DiemViet { get; set; }
        public virtual DeThiViewModel Dethi { get; set; }
        public virtual HocVienViewModel HocVien { get; set; }
        public virtual IEnumerable<CauTraLoiBaiLamViewModel> CauTraLoiBaiLams { get; set; }
    }
}