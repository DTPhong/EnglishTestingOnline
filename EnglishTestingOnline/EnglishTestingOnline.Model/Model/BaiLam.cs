using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{   [Table("BaiLams")]
    public class BaiLam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int HocVien_ID { get; set; }
        [Required]
        public int DeThi_ID { get; set; }
        public float? DiemNghe { get; set; }
        public float? DiemNoi { get; set; }
        public float? DiemDoc { get; set; }
        public float? DiemViet { get; set; }
        [ForeignKey("DeThi_ID")]
        public virtual DeThi Dethi { get; set; }
        [ForeignKey("HocVien_ID")]
        public virtual HocVien HocVien { get; set; }
        public virtual IEnumerable<CauTraLoiBaiLam> CauTraLoiBaiLams { get; set; }

    }
}
