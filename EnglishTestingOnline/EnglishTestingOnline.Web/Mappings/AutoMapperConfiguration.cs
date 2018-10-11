using AutoMapper;
using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishTestingOnline.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CauHoi, CauHoiViewModel>();
                cfg.CreateMap<BaiDocNghe, BaiDocNgheViewModel>();
                cfg.CreateMap<ChuDe, ChuDeViewModel>();
                cfg.CreateMap<LoaiBaiDocNghe, LoaiBaiDocNgheViewModel>();
                cfg.CreateMap<LoaiCauHoi, LoaiCauHoiViewModel>();
            });
        }
    }
}