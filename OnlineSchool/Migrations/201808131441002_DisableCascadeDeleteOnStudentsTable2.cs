namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisableCascadeDeleteOnStudentsTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ChurchId", "dbo.Churches");
            DropIndex("dbo.Students", new[] { "ChurchId" });
            AddColumn("dbo.Students", "Church_Id", c => c.Int());
            CreateIndex("dbo.Students", "Church_Id");
            AddForeignKey("dbo.Students", "Church_Id", "dbo.Churches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Church_Id", "dbo.Churches");
            DropIndex("dbo.Students", new[] { "Church_Id" });
            DropColumn("dbo.Students", "Church_Id");
            CreateIndex("dbo.Students", "ChurchId");
            AddForeignKey("dbo.Students", "ChurchId", "dbo.Churches", "Id", cascadeDelete: true);
        }
    }
}
