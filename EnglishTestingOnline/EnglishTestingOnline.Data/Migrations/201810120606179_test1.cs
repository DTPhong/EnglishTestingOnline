namespace EnglishTestingOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.IdentityUserLogins");
            DropPrimaryKey("dbo.IdentityUserClaims");
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IdentityUserRoles", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserLogins", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserClaims", "IdentityUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserLogins", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserClaims", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.IdentityUserLogins", new[] { "UserId", "ProviderKey", "LoginProvider" });
            AddPrimaryKey("dbo.IdentityUserClaims", "Id");
            CreateIndex("dbo.IdentityUserRoles", "IdentityUser_Id");
            CreateIndex("dbo.IdentityUserClaims", "IdentityUser_Id");
            CreateIndex("dbo.IdentityUserLogins", "IdentityUser_Id");
            AddForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.IdentityUserLogins", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.IdentityUserRoles", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserLogins", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropIndex("dbo.IdentityUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityUser_Id" });
            DropPrimaryKey("dbo.IdentityUserClaims");
            DropPrimaryKey("dbo.IdentityUserLogins");
            AlterColumn("dbo.IdentityUserClaims", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserLogins", "ProviderKey", c => c.String());
            AlterColumn("dbo.IdentityUserLogins", "LoginProvider", c => c.String());
            DropColumn("dbo.IdentityUserClaims", "IdentityUser_Id");
            DropColumn("dbo.IdentityUserLogins", "IdentityUser_Id");
            DropColumn("dbo.IdentityUserRoles", "IdentityUser_Id");
            DropTable("dbo.IdentityUsers");
            AddPrimaryKey("dbo.IdentityUserClaims", "UserId");
            AddPrimaryKey("dbo.IdentityUserLogins", "UserId");
        }
    }
}
