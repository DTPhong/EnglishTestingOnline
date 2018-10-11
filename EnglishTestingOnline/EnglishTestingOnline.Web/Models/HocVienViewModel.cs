using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class HocVienViewModel
    {
        public int ID { get; set; }
        public string Ten { get; set; }

        public DateTime NgaySinh { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }
        public virtual IEnumerable<BaiLamViewModel> BaiLams { get; set; }
    }
}