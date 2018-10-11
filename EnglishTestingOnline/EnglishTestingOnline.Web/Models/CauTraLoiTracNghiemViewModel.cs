using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class CauTraLoiTracNghiemViewModel
    {
        public int ID { get; set; }
        public int CauHoi_ID { get; set; }
        public int LoaiCauTraLoi_ID { get; set; }
        public string NoiDung { get; set; }
        public virtual LoaiCauTraLoiTracNghiem LoaiCauTraLoiTracNghiem { get; set; }
        public virtual CauHoi CauHoi { get; set; }
    }
}