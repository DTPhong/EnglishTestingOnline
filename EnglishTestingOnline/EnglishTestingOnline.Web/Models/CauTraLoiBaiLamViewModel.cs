using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class CauTraLoiBaiLamViewModel
    {
        public int BaiLam_ID { get; set; }
        public int CauHoi_ID { get; set; }
        public string CauTraLoi { get; set; }
        public virtual CauHoi CauHoi { get; set; }
        public virtual BaiLam BaiLam { get; set; }
    }
}