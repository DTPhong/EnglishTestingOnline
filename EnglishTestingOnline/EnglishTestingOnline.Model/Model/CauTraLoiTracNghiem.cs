using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{
    [Table("CauTraLoiTracNghiems")]
    public class CauTraLoiTracNghiem
    {
        [Key]
        public int ID { get; set; }
        public int CauHoi_ID { get; set; }
        public int LoaiCauTraLoi_ID { get; set; }
        [StringLength(250)]
        public string NoiDung { get; set; }
        [ForeignKey("LoaiCauTraLoi_ID")]
        public virtual LoaiCauTraLoiTracNghiem LoaiCauTraLoiTracNghiems { get; set; }
        [ForeignKey("CauHoi_ID")]
        public virtual CauHoi CauHois { get; set; }
    }
}
