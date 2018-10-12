using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Models
{
    public class CauHoiViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Bạn phải chọn loại câu hỏi.")]
        public int LoaiCauHoi_ID { get; set; }
        public int? BaiDocNghe_ID { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn chủ đề.")]
        public int ChuDe_ID { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập nội dung câu hỏi.")]
        public string NoiDung { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập đáp án.")]
        public string DapAn { get; set; }
        public virtual LoaiCauHoiViewModel LoaiCauHoi { get; set; }
        public virtual BaiDocNgheViewModel BaiDocNghe { get; set; }
        public virtual ChuDeViewModel ChuDe { get; set; }
    }
}