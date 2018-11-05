using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{
    [Table("Kythi")]
    public class KyThi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(250)]
        public string TenKyThi { get; set; }
        [Required]
        public DateTime NgayThi { get; set; }
        public virtual IEnumerable<DeThi> DeThis { get; set; }
    }
}
