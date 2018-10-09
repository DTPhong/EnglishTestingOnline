using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{
    [Table("CauHois")]
    public class CauHoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int LoaiCauHoi_ID { get; set; }
        public int BaiDocNghe_ID { get; set; }
        public int ChuDe_ID { get; set; }
        [Required]
        [StringLength(500)]
        public string NoiDung { get; set; }
        [Required]
        [StringLength(250)]
        public string DapAn { get; set; }
        [ForeignKey("LoaiCauHoi_ID")]
        public virtual LoaiCauHoi LoaiCauHois { get; set; }
        [ForeignKey("BaiDocNghe_ID")]
        public virtual BaiDocNghe BaiDocNghes { get; set; }
        [ForeignKey("ChuDe_ID")]
        public virtual ChuDe ChuDe { get; set; }
        public virtual IEnumerable<CauHoiDeThi> CauHoiDeThis { get; set; }
        public virtual IEnumerable<CauTraLoiTracNghiem> CauTraLoiTracNghiems { get; set; }
        public virtual IEnumerable<CauTraLoiBaiLam> CauTraLoiBaiLams { get; set; }


    }
}
