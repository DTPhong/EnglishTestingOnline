using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{
    [Table("DeThi")]
    public class DeThi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int KyThi_ID { get; set; }
        [Required]
        public DateTime ThoiGianThi { get; set; }
        [Required]
        public DateTime ThoiGianBatDau { get; set; }
        [ForeignKey("KyThi_ID")]
        public virtual KyThi KyThi { get; set; }
        public virtual IEnumerable<BaiLam> BaiLams { get; set; }
        public virtual IEnumerable<CauHoiDeThi> CauHoiDeThis { get; set; }
    }
}
