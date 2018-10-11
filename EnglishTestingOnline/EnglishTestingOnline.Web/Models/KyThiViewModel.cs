using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class KyThiViewModel
    {
        public int ID { get; set; }
        public string TenKyThi { get; set; }
        public DateTime NgayThi { get; set; }
        public virtual IEnumerable<DeThi> DeThis { get; set; }
    }
}