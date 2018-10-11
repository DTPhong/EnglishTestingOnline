using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class CauHoiDeThiViewModel
    {
        public int DeThi_ID { get; set; }

        public int CauHoi_ID { get; set; }

        public virtual DeThiViewModel DeThi { get; set; }

        public virtual CauHoiViewModel CauHoi { get; set; }
        public virtual IEnumerable<CauHoiViewModel> CauHois { get; set; }
    }
}