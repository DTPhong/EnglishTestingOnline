using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{[Table("CauHoiDeThis")]
    public class CauHoiDeThi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int DeThi_ID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 2)]
        public int CauHoi_ID { get; set; }
        [ForeignKey("CauHoi_ID")]
        public virtual IEnumerable<CauHoi> CauHois { get; set; }
    }
}
