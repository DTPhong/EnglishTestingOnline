using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class BaiDocNgheViewModel
    {
        public int ID { get; set; }
        public int? LoaiBaiDocNghe_ID { get; set; }
        public string NoiDung { get; set; }
        
        public virtual LoaiBaiDocNgheViewModel LoaiBaiDocNghe { get; set; }
    }
}