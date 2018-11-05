namespace EnglishTestingOnline.Data.Migrations
{
    using EnglishTestingOnline.Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EnglishDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EnglishDbContext context)
        {
            CreateKyThiSample(context);
            CreateDethiSample(context);
            CreateLoaiBaiDocNgheSample(context);
            CreateBaiDocNgheSample(context);
            CreateChudeSample(context);
            CreateLoaiCauHoiSample(context);
            CreateCauHoiSample(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
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
        private void CreateLoaiBaiDocNgheSample(EnglishDbContext context)
        {
            if (context.LoaiBaiDocNghes.Count() == 0)
            {
                List<LoaiBaiDocNghe> listLoaiBaiDocNghe = new List<LoaiBaiDocNghe>()
            {
                    new LoaiBaiDocNghe()
                    {

                       Name="Nghe",
                    },
                    new LoaiBaiDocNghe()
                    {

                       Name="Đọc",
                    },
            };
                context.LoaiBaiDocNghes.AddRange(listLoaiBaiDocNghe);
                context.SaveChanges();
            }
        }
        private void CreateBaiDocNgheSample(EnglishDbContext context)
        {
            if (context.BaiDocNghes.Count() == 0)
            {
                List<BaiDocNghe> listBaiDocNghe = new List<BaiDocNghe>()
            {
                    new BaiDocNghe()
                    {

                       LoaiBaiDocNghe_ID=1,
                       NoiDung="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    },
                    new BaiDocNghe()
                    {

                       LoaiBaiDocNghe_ID=2,
                       NoiDung="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",

                    },
                    new BaiDocNghe()
                    {

                       LoaiBaiDocNghe_ID=2,
                       NoiDung="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",

                    },
                    new BaiDocNghe()
                    {

                       LoaiBaiDocNghe_ID=1,
                       NoiDung="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",

                    },
            };
                context.BaiDocNghes.AddRange(listBaiDocNghe);
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
                        BaiDocNghe_ID=2,
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
                        BaiDocNghe_ID=4,
                        ChuDe_ID=3,
                        NoiDung="Noi dung cau hoi",
                        DapAn="Dap an cau hoi"
                    },
                    new CauHoi()
                    {
                        LoaiCauHoi_ID=1,
                        BaiDocNghe_ID=3,
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
                        BaiDocNghe_ID=2,
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
        private void CreateKyThiSample(EnglishDbContext context)
        {
            if (context.KyThis.Count() == 0)
            {
                List<KyThi> listKythi = new List<KyThi>()
            {
                    new KyThi()
                    {

                        TenKyThi="IELTS Spring Examination",
                    NgayThi=Convert.ToDateTime("2018-11-05 00:00:00.000"),

                    },
                    new KyThi()
                    {

                        TenKyThi="IELTS Summer Examination",
                        NgayThi=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                    },
                    new KyThi()
                    {

                        TenKyThi="IELTS Authumn Examination",
                        //NgayThi=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                    },
                    new KyThi()
                    {

                        TenKyThi="IELTS Winter Examination"
                        ,NgayThi=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                    }
            };
                context.KyThis.AddRange(listKythi);
                context.SaveChanges();
            }
        }
        private void CreateDethiSample(EnglishDbContext context)
        {
            if (context.DeThis.Count() == 0)
            {
                List<DeThi> listDethi = new List<DeThi>()
            {
                    new DeThi()
                    {

                        KyThi_ID=1,
                        ThoiGianBatDau=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                        ThoiGianThi=Convert.ToDateTime("2018-11-05 00:00:00.000"),

                    },
                    new DeThi()
                    {

                        KyThi_ID=2,
                        ThoiGianBatDau=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                        ThoiGianThi=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                    },
                    new DeThi()
                    {

                        KyThi_ID=3,
                        ThoiGianBatDau=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                        ThoiGianThi=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                    },
                    new DeThi()
                    {

                        KyThi_ID=4,
                        ThoiGianBatDau=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                        ThoiGianThi=Convert.ToDateTime("2018-11-05 00:00:00.000"),
                    }
            };
                context.DeThis.AddRange(listDethi);
                context.SaveChanges();
            }
        }

    }
}