namespace EnglishTestingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaiDocNghe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoaiBaiDocNghe_ID = c.Int(),
                        NoiDung = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LoaiBaiDocNghe", t => t.LoaiBaiDocNghe_ID)
                .Index(t => t.LoaiBaiDocNghe_ID);
            
            CreateTable(
                "dbo.LoaiBaiDocNghe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BaiLam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HocVien_ID = c.String(nullable: false, maxLength: 128),
                        DeThi_ID = c.Int(nullable: false),
                        DiemNghe = c.Single(),
                        DiemNoi = c.Single(),
                        DiemDoc = c.Single(),
                        DiemViet = c.Single(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.HocVien_ID, cascadeDelete: true)
                .ForeignKey("dbo.DeThi", t => t.DeThi_ID, cascadeDelete: true)
                .Index(t => t.HocVien_ID)
                .Index(t => t.DeThi_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AccountName = c.String(),
                        Address = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.DeThi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KyThi_ID = c.Int(nullable: false),
                        ThoiGianThi = c.DateTime(nullable: false),
                        ThoiGianBatDau = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kythi", t => t.KyThi_ID, cascadeDelete: true)
                .Index(t => t.KyThi_ID);
            
            CreateTable(
                "dbo.Kythi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenKyThi = c.String(nullable: false, maxLength: 250),
                        NgayThi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CauHoiDeThi",
                c => new
                    {
                        DeThi_ID = c.Int(nullable: false),
                        CauHoi_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeThi_ID, t.CauHoi_ID })
                .ForeignKey("dbo.CauHoi", t => t.CauHoi_ID, cascadeDelete: true)
                .ForeignKey("dbo.DeThi", t => t.DeThi_ID, cascadeDelete: true)
                .Index(t => t.DeThi_ID)
                .Index(t => t.CauHoi_ID);
            
            CreateTable(
                "dbo.CauHoi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoaiCauHoi_ID = c.Int(nullable: false),
                        BaiDocNghe_ID = c.Int(),
                        ChuDe_ID = c.Int(nullable: false),
                        NoiDung = c.String(nullable: false, maxLength: 500),
                        DapAn = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BaiDocNghe", t => t.BaiDocNghe_ID)
                .ForeignKey("dbo.ChuDe", t => t.ChuDe_ID, cascadeDelete: true)
                .ForeignKey("dbo.LoaiCauHoi", t => t.LoaiCauHoi_ID, cascadeDelete: true)
                .Index(t => t.LoaiCauHoi_ID)
                .Index(t => t.BaiDocNghe_ID)
                .Index(t => t.ChuDe_ID);
            
            CreateTable(
                "dbo.ChuDe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenChuDe = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LoaiCauHoi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CauTraLoiBaiLam",
                c => new
                    {
                        BaiLam_ID = c.Int(nullable: false),
                        CauHoi_ID = c.Int(nullable: false),
                        CauTraLoi = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.BaiLam_ID, t.CauHoi_ID })
                .ForeignKey("dbo.BaiLam", t => t.BaiLam_ID, cascadeDelete: true)
                .ForeignKey("dbo.CauHoi", t => t.CauHoi_ID, cascadeDelete: true)
                .Index(t => t.BaiLam_ID)
                .Index(t => t.CauHoi_ID);
            
            CreateTable(
                "dbo.CauTraLoiTracNghiem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CauHoi_ID = c.Int(nullable: false),
                        LoaiCauTraLoi_ID = c.Int(nullable: false),
                        NoiDung = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.ID, t.CauHoi_ID })
                .ForeignKey("dbo.CauHoi", t => t.CauHoi_ID, cascadeDelete: true)
                .ForeignKey("dbo.LoaiCauTraLoiTracNghiem", t => t.LoaiCauTraLoi_ID, cascadeDelete: true)
                .Index(t => t.CauHoi_ID)
                .Index(t => t.LoaiCauTraLoi_ID);
            
            CreateTable(
                "dbo.LoaiCauTraLoiTracNghiem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoaiCauTraLoi = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CauTraLoiTracNghiem", "LoaiCauTraLoi_ID", "dbo.LoaiCauTraLoiTracNghiem");
            DropForeignKey("dbo.CauTraLoiTracNghiem", "CauHoi_ID", "dbo.CauHoi");
            DropForeignKey("dbo.CauTraLoiBaiLam", "CauHoi_ID", "dbo.CauHoi");
            DropForeignKey("dbo.CauTraLoiBaiLam", "BaiLam_ID", "dbo.BaiLam");
            DropForeignKey("dbo.CauHoiDeThi", "DeThi_ID", "dbo.DeThi");
            DropForeignKey("dbo.CauHoiDeThi", "CauHoi_ID", "dbo.CauHoi");
            DropForeignKey("dbo.CauHoi", "LoaiCauHoi_ID", "dbo.LoaiCauHoi");
            DropForeignKey("dbo.CauHoi", "ChuDe_ID", "dbo.ChuDe");
            DropForeignKey("dbo.CauHoi", "BaiDocNghe_ID", "dbo.BaiDocNghe");
            DropForeignKey("dbo.BaiLam", "DeThi_ID", "dbo.DeThi");
            DropForeignKey("dbo.DeThi", "KyThi_ID", "dbo.Kythi");
            DropForeignKey("dbo.BaiLam", "HocVien_ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BaiDocNghe", "LoaiBaiDocNghe_ID", "dbo.LoaiBaiDocNghe");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CauTraLoiTracNghiem", new[] { "LoaiCauTraLoi_ID" });
            DropIndex("dbo.CauTraLoiTracNghiem", new[] { "CauHoi_ID" });
            DropIndex("dbo.CauTraLoiBaiLam", new[] { "CauHoi_ID" });
            DropIndex("dbo.CauTraLoiBaiLam", new[] { "BaiLam_ID" });
            DropIndex("dbo.CauHoi", new[] { "ChuDe_ID" });
            DropIndex("dbo.CauHoi", new[] { "BaiDocNghe_ID" });
            DropIndex("dbo.CauHoi", new[] { "LoaiCauHoi_ID" });
            DropIndex("dbo.CauHoiDeThi", new[] { "CauHoi_ID" });
            DropIndex("dbo.CauHoiDeThi", new[] { "DeThi_ID" });
            DropIndex("dbo.DeThi", new[] { "KyThi_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BaiLam", new[] { "DeThi_ID" });
            DropIndex("dbo.BaiLam", new[] { "HocVien_ID" });
            DropIndex("dbo.BaiDocNghe", new[] { "LoaiBaiDocNghe_ID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LoaiCauTraLoiTracNghiem");
            DropTable("dbo.CauTraLoiTracNghiem");
            DropTable("dbo.CauTraLoiBaiLam");
            DropTable("dbo.LoaiCauHoi");
            DropTable("dbo.ChuDe");
            DropTable("dbo.CauHoi");
            DropTable("dbo.CauHoiDeThi");
            DropTable("dbo.Kythi");
            DropTable("dbo.DeThi");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BaiLam");
            DropTable("dbo.LoaiBaiDocNghe");
            DropTable("dbo.BaiDocNghe");
        }
    }
}
