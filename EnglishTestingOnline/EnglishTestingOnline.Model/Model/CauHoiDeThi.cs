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
        [Column(Order = 1)]
        public int DeThi_ID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CauHoi_ID { get; set; }
    }
}
