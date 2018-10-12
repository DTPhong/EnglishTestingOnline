namespace EnglishTestingOnline.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using EnglishTestingOnline.Model.Model;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class EnglishDbContext : IdentityDbContext<UserApplication>
    {
        // Your context has been configured to use a 'EnglishDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EnglishTestingOnline.Data.EnglishDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EnglishDbContext' 
        // connection string in the application configuration file.
        public EnglishDbContext()
            : base("name=EnglishDbContext")
        {
        }
        public static EnglishDbContext Create()
        {
            return new EnglishDbContext();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<BaiDocNghe> BaiDocNghes { get; set; }
        public virtual DbSet<BaiLam> BaiLams { get; set; }
        public virtual DbSet<CauHoi> CauHois { get; set; }
        public virtual DbSet<CauHoiDeThi> CauHoiDeThis { get; set; }
        public virtual DbSet<CauTraLoiBaiLam> CauTraLoiBaiLams { get; set; }
        public virtual DbSet<CauTraLoiTracNghiem> CauTraLoiTracNghiems { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<DeThi> DeThis { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<KyThi> KyThis { get; set; }
        public virtual DbSet<LoaiBaiDocNghe> LoaiBaiDocNghes { get; set; }
        public virtual DbSet<LoaiCauHoi> LoaiCauHois { get; set; }
        public virtual DbSet<LoaiCauTraLoiTracNghiem> LoaiCauTraLoiTracNghiems { get; set; }
        //public virtual DbSet<IdentityUserRole> IdentityUserRoles { get; set; }
        //public virtual DbSet<IdentityUser> IdentityUsers { get; set; }
        //public virtual DbSet<IdentityUserClaim> IdentityUserClaims { get; set; }
        //public virtual DbSet<IdentityRole> IdentityRoles { get; set; }
        //public virtual DbSet<IdentityUserLogin> IdentityUserLogins { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUser>().HasKey(i => i.Id);
            builder.Entity<IdentityRole>().HasKey(i => i.Id);
            builder.Entity<IdentityUserClaim>().HasKey(i => i.Id);
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => new { i.UserId, i.ProviderKey, i.LoginProvider });
            
         
            
        }
    }

   
}