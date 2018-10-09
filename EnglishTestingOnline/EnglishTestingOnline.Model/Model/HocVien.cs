using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{
    [Table("HocViens")]
    public class HocVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(250)]
        public string Ten { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        [Required]
        [StringLength(250)]
        public string DiaChi { get; set; }
        public virtual IEnumerable<BaiLam> BaiLams { get; set; }


    }
}
