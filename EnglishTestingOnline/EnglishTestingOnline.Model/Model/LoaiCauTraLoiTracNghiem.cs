﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Model.Model
{
    [Table("LoaiCauTraLoiTracNghiems")]
    public class LoaiCauTraLoiTracNghiem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(250)]
        public string LoaiCauTraLoi { get; set; }
        public virtual IEnumerable<CauTraLoiTracNghiem> CauTraLoiTracNghiems { get; set; }
    }
}
