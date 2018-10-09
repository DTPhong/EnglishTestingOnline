namespace EnglishTestingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addshocvien : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.HocVien", newName: "HocViens");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.HocViens", newName: "HocVien");
        }
    }
}
