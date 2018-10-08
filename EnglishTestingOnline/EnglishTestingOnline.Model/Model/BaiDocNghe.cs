using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{
    [Table("BaiDocNghes")]
    class BaiDocNghe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int LoaiBaiDocNghe_ID { get; set; }
        [Required]
        [StringLength(250)]
        public string NoiDung { get; set; }
    }
}
