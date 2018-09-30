namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisableCascadeDeleteOnStudentsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "PriestId", "dbo.Priests");
            DropIndex("dbo.Students", new[] { "PriestId" });
            AddColumn("dbo.Students", "Priest_Id", c => c.Int());
            CreateIndex("dbo.Students", "Priest_Id");
            AddForeignKey("dbo.Students", "Priest_Id", "dbo.Priests", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Priest_Id", "dbo.Priests");
            DropIndex("dbo.Students", new[] { "Priest_Id" });
            DropColumn("dbo.Students", "Priest_Id");
            CreateIndex("dbo.Students", "PriestId");
            AddForeignKey("dbo.Students", "PriestId", "dbo.Priests", "Id", cascadeDelete: true);
        }
    }
}
