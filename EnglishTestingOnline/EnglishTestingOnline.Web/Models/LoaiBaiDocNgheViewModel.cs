using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class LoaiBaiDocNgheViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<BaiDocNgheViewModel> BaiDocNghes { get; set; }
    }
}