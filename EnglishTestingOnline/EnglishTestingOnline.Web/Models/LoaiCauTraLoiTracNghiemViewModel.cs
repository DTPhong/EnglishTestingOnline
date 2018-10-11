using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class LoaiCauTraLoiTracNghiemViewModel
    {
        public int ID { get; set; }
        
        public string LoaiCauTraLoi { get; set; }
        public virtual IEnumerable<CauTraLoiTracNghiemViewModel> CauTraLoiTracNghiems { get; set; }
    }
}