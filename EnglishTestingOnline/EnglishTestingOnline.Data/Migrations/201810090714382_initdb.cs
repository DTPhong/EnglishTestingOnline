namespace EnglishTestingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaiDocNghes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoaiBaiDocNghe_ID = c.Int(),
                        NoiDung = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LoaiBaiDocNghes", t => t.LoaiBaiDocNghe_ID)
                .Index(t => t.LoaiBaiDocNghe_ID);
            
            CreateTable(
                "dbo.LoaiBaiDocNghes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BaiLams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HocVien_ID = c.Int(nullable: false),
                        DeThi_ID = c.Int(nullable: false),
                        DiemNghe = c.Single(),
                        DiemNoi = c.Single(),
                        DiemDoc = c.Single(),
                        DiemViet = c.Single(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DeThis", t => t.DeThi_ID, cascadeDelete: true)
                .ForeignKey("dbo.HocVien", t => t.HocVien_ID, cascadeDelete: true)
                .Index(t => t.HocVien_ID)
                .Index(t => t.DeThi_ID);
            
            CreateTable(
                "dbo.DeThis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KyThi_ID = c.Int(nullable: false),
                        ThoiGianThi = c.DateTime(nullable: false),
                        ThoiGianBatDau = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kythis", t => t.KyThi_ID, cascadeDelete: true)
                .Index(t => t.KyThi_ID);
            
            CreateTable(
                "dbo.Kythis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenKyThi = c.String(nullable: false, maxLength: 250),
                        NgayThi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HocVien",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 250),
                        NgaySinh = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 250),
                        DiaChi = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CauHoiDeThis",
                c => new
                    {
                        DeThi_ID = c.Int(nullable: false),
                        CauHoi_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeThi_ID, t.CauHoi_ID })
                .ForeignKey("dbo.CauHois", t => t.CauHoi_ID, cascadeDelete: true)
                .ForeignKey("dbo.DeThis", t => t.DeThi_ID, cascadeDelete: true)
                .Index(t => t.DeThi_ID)
                .Index(t => t.CauHoi_ID);
            
            CreateTable(
                "dbo.CauHois",
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
                .ForeignKey("dbo.BaiDocNghes", t => t.BaiDocNghe_ID)
                .ForeignKey("dbo.ChuDes", t => t.ChuDe_ID, cascadeDelete: true)
                .ForeignKey("dbo.LoaiCauHois", t => t.LoaiCauHoi_ID, cascadeDelete: true)
                .Index(t => t.LoaiCauHoi_ID)
                .Index(t => t.BaiDocNghe_ID)
                .Index(t => t.ChuDe_ID);
            
            CreateTable(
                "dbo.ChuDes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenChuDe = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LoaiCauHois",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CauTraLoiBaiLams",
                c => new
                    {
                        BaiLam_ID = c.Int(nullable: false),
                        CauHoi_ID = c.Int(nullable: false),
                        CauTraLoi = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.BaiLam_ID, t.CauHoi_ID })
                .ForeignKey("dbo.BaiLams", t => t.BaiLam_ID, cascadeDelete: true)
                .ForeignKey("dbo.CauHois", t => t.CauHoi_ID, cascadeDelete: true)
                .Index(t => t.BaiLam_ID)
                .Index(t => t.CauHoi_ID);
            
            CreateTable(
                "dbo.CauTraLoiTracNghiems",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CauHoi_ID = c.Int(nullable: false),
                        LoaiCauTraLoi_ID = c.Int(nullable: false),
                        NoiDung = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.ID, t.CauHoi_ID })
                .ForeignKey("dbo.CauHois", t => t.CauHoi_ID, cascadeDelete: true)
                .ForeignKey("dbo.LoaiCauTraLoiTracNghiems", t => t.LoaiCauTraLoi_ID, cascadeDelete: true)
                .Index(t => t.CauHoi_ID)
                .Index(t => t.LoaiCauTraLoi_ID);
            
            CreateTable(
                "dbo.LoaiCauTraLoiTracNghiems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoaiCauTraLoi = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CauTraLoiTracNghiems", "LoaiCauTraLoi_ID", "dbo.LoaiCauTraLoiTracNghiems");
            DropForeignKey("dbo.CauTraLoiTracNghiems", "CauHoi_ID", "dbo.CauHois");
            DropForeignKey("dbo.CauTraLoiBaiLams", "CauHoi_ID", "dbo.CauHois");
            DropForeignKey("dbo.CauTraLoiBaiLams", "BaiLam_ID", "dbo.BaiLams");
            DropForeignKey("dbo.CauHoiDeThis", "DeThi_ID", "dbo.DeThis");
            DropForeignKey("dbo.CauHoiDeThis", "CauHoi_ID", "dbo.CauHois");
            DropForeignKey("dbo.CauHois", "LoaiCauHoi_ID", "dbo.LoaiCauHois");
            DropForeignKey("dbo.CauHois", "ChuDe_ID", "dbo.ChuDes");
            DropForeignKey("dbo.CauHois", "BaiDocNghe_ID", "dbo.BaiDocNghes");
            DropForeignKey("dbo.BaiLams", "HocVien_ID", "dbo.HocVien");
            DropForeignKey("dbo.BaiLams", "DeThi_ID", "dbo.DeThis");
            DropForeignKey("dbo.DeThis", "KyThi_ID", "dbo.Kythis");
            DropForeignKey("dbo.BaiDocNghes", "LoaiBaiDocNghe_ID", "dbo.LoaiBaiDocNghes");
            DropIndex("dbo.CauTraLoiTracNghiems", new[] { "LoaiCauTraLoi_ID" });
            DropIndex("dbo.CauTraLoiTracNghiems", new[] { "CauHoi_ID" });
            DropIndex("dbo.CauTraLoiBaiLams", new[] { "CauHoi_ID" });
            DropIndex("dbo.CauTraLoiBaiLams", new[] { "BaiLam_ID" });
            DropIndex("dbo.CauHois", new[] { "ChuDe_ID" });
            DropIndex("dbo.CauHois", new[] { "BaiDocNghe_ID" });
            DropIndex("dbo.CauHois", new[] { "LoaiCauHoi_ID" });
            DropIndex("dbo.CauHoiDeThis", new[] { "CauHoi_ID" });
            DropIndex("dbo.CauHoiDeThis", new[] { "DeThi_ID" });
            DropIndex("dbo.DeThis", new[] { "KyThi_ID" });
            DropIndex("dbo.BaiLams", new[] { "DeThi_ID" });
            DropIndex("dbo.BaiLams", new[] { "HocVien_ID" });
            DropIndex("dbo.BaiDocNghes", new[] { "LoaiBaiDocNghe_ID" });
            DropTable("dbo.LoaiCauTraLoiTracNghiems");
            DropTable("dbo.CauTraLoiTracNghiems");
            DropTable("dbo.CauTraLoiBaiLams");
            DropTable("dbo.LoaiCauHois");
            DropTable("dbo.ChuDes");
            DropTable("dbo.CauHois");
            DropTable("dbo.CauHoiDeThis");
            DropTable("dbo.HocVien");
            DropTable("dbo.Kythis");
            DropTable("dbo.DeThis");
            DropTable("dbo.BaiLams");
            DropTable("dbo.LoaiBaiDocNghes");
            DropTable("dbo.BaiDocNghes");
        }
    }
}
