using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{   [Table("CauTraLoiBaiLams")]
    class CauTraLoiBaiLam
    {
        [Key]
        [Column(Order = 1)]
        public int BaiLam_ID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CauHoi_ID { get; set; }
        [StringLength(250)]
        public string CauTraLoi { get; set; }

    }
}
