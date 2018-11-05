namespace EnglishTestingOnline.Data.Migrations
{
    using EnglishTestingOnline.Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EnglishDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EnglishTestingOnline.Data.EnglishDbContext context)
        {
            CreateChudeSample(context);
            CreateLoaiCauHoiSample(context);
            CreateCauHoiSample(context);
            CreateKyThiSample(context);
        }

        private void CreateKyThiSample(EnglishDbContext context)
        {
            if (context.KyThis.Count() == 0)
            {
                List<KyThi> listKyThi = new List<KyThi>
                {
                    new KyThi(){TenKyThi="Test1",NgayThi=DateTime.Now},
                    new KyThi(){TenKyThi="Test2",NgayThi=DateTime.Now},
                    new KyThi(){TenKyThi="Test3",NgayThi=DateTime.Now},
                    new KyThi(){TenKyThi="Test4",NgayThi=DateTime.Now},
                    new KyThi(){TenKyThi="Test5",NgayThi=DateTime.Now}
                };
                context.KyThis.AddRange(listKyThi);
                context.SaveChanges();
            }
        }

        private void CreateChudeSample(EnglishDbContext context)
        {
            if (context.ChuDes.Count() == 0)
            {
                List<ChuDe> listChuDe = new List<ChuDe>()
            {
                    new ChuDe()
                    {
                        TenChuDe="Reading"
                    },
                    new ChuDe()
                    {
                        TenChuDe="Speaking"
                    },
                    new ChuDe()
                    {
                        TenChuDe="Listening"
                    },
                    new ChuDe()
                    {
                        TenChuDe="Writing"
                    }
            };
                context.ChuDes.AddRange(listChuDe);
                context.SaveChanges();
            }
        }

        private void CreateLoaiCauHoiSample(EnglishDbContext context)
        {
            if (context.LoaiCauHois.Count() == 0)
            {
                List<LoaiCauHoi> listLoaiCauHoi = new List<LoaiCauHoi>()
            {
                    new LoaiCauHoi()
                    {
                        NoiDung="Multiple-choice"
                    },
                    new LoaiCauHoi()
                    {
                        NoiDung="Essay"
                    },
            };
                context.LoaiCauHois.AddRange(listLoaiCauHoi);
                context.SaveChanges();
            }
        }

        private void CreateCauHoiSample(EnglishDbContext context)
        {
            if (context.CauHois.Count() == 0)
            {
                List<CauHoi> listCauHoi = new List<CauHoi>()
            {
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=1,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    }
            };
                context.CauHois.AddRange(listCauHoi);
                context.SaveChanges();
            }
        }
    }
}