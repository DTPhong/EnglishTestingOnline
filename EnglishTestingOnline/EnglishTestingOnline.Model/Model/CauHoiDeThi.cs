using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{[Table("CauHoiDeThi")]
    public class CauHoiDeThi
    {
        [Key]
        [Column(Order = 1)]
        public int DeThi_ID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CauHoi_ID { get; set; }
        [ForeignKey("DeThi_ID")]
        public virtual DeThi DeThi { get; set; }
        [ForeignKey("CauHoi_ID")]
        public virtual CauHoi CauHoi { get; set; }
        public virtual IEnumerable<CauHoi> CauHois { get; set; }
    }
}
