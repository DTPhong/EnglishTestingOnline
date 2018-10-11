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

        public virtual KyThiViewModel KyThi { get; set; }
        public virtual IEnumerable<BaiLamViewModel> BaiLams { get; set; }
        public virtual IEnumerable<CauHoiDeThiViewModel> CauHoiDeThis { get; set; }
    }
}