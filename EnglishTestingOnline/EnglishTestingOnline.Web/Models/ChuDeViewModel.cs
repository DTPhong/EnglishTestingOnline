using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class ChuDeViewModel
    {   
        public int ID { get; set; }
        public string TenChuDe { get; set; }
        public virtual IEnumerable<CauHoiViewModel> CauHois { get; set; }
    }
}