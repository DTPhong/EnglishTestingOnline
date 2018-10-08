using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{
    [Table("Kythis")]
    class KyThi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string TenKyThi { get; set; }
        [Required]
        [StringLength(250)]
        public DateTime? NgayThi { get; set; }
        public virtual IEnumerable<CauTraLoiBaiLam> CauTraLoiBaiLams { get; set; }
    }
}
