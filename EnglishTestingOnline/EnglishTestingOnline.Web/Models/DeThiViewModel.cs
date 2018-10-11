using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class DeThiViewModel
    {
        public int ID { get; set; }

        public int KyThi_ID { get; set; }

        public DateTime ThoiGianThi { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public virtual KyThi KyThi { get; set; }
        public virtual IEnumerable<BaiLam> BaiLams { get; set; }
        public virtual IEnumerable<CauHoiDeThi> CauHoiDeThis { get; set; }
    }
}