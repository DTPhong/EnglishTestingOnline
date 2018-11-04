namespace EnglishTestingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class completeDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaiLams", "HocVien_ID", "dbo.HocViens");
            DropIndex("dbo.BaiLams", new[] { "HocVien_ID" });
            AlterColumn("dbo.BaiLams", "HocVien_ID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.BaiLams", "HocVien_ID");
            AddForeignKey("dbo.BaiLams", "HocVien_ID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropTable("dbo.HocViens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HocViens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 250),
                        NgaySinh = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 250),
                        DiaChi = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.BaiLams", "HocVien_ID", "dbo.AspNetUsers");
            DropIndex("dbo.BaiLams", new[] { "HocVien_ID" });
            AlterColumn("dbo.BaiLams", "HocVien_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.BaiLams", "HocVien_ID");
            AddForeignKey("dbo.BaiLams", "HocVien_ID", "dbo.HocViens", "ID", cascadeDelete: true);
        }
    }
}
