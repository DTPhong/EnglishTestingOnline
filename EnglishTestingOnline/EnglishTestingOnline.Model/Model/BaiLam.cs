using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{   [Table("BaiLams")]
    class BaiLam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int HocVien_ID { get; set; }
        public int DeThi_ID { get; set; }
        public int DiemNghe { get; set; }
        public int DiemNoi { get; set; }
        public int DiemDoc { get; set; }
        public int DiemViet { get; set; }
    }
}
