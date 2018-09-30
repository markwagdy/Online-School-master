namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserKeyToModelTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servants", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Students", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Servants", "ApplicationUser_Id");
            CreateIndex("dbo.Students", "ApplicationUser_Id");
            AddForeignKey("dbo.Servants", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Students", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Servants", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Servants", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Students", "ApplicationUser_Id");
            DropColumn("dbo.Servants", "ApplicationUser_Id");
        }
    }
}
