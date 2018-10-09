namespace EnglishTestingOnline.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EnglishTestingOnline.Model.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<EnglishTestingOnline.Data.EnglishDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EnglishTestingOnline.Data.EnglishDbContext context)
        {
            CreateChudeSample(context);
            CreateLoaiCauHoiSample(context);
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
    }
}
