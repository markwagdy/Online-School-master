namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriestAndChurchId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Church_Id", "dbo.Churches");
            DropForeignKey("dbo.Students", "Priest_Id", "dbo.Priests");
            DropIndex("dbo.Students", new[] { "Church_Id" });
            DropIndex("dbo.Students", new[] { "Priest_Id" });
            RenameColumn(table: "dbo.Students", name: "Church_Id", newName: "ChurchId");
            RenameColumn(table: "dbo.Students", name: "Priest_Id", newName: "PriestId");
            AlterColumn("dbo.Students", "ChurchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "PriestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "PriestId");
            CreateIndex("dbo.Students", "ChurchId");
            AddForeignKey("dbo.Students", "ChurchId", "dbo.Churches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "PriestId", "dbo.Priests", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "PriestId", "dbo.Priests");
            DropForeignKey("dbo.Students", "ChurchId", "dbo.Churches");
            DropIndex("dbo.Students", new[] { "ChurchId" });
            DropIndex("dbo.Students", new[] { "PriestId" });
            AlterColumn("dbo.Students", "PriestId", c => c.Int());
            AlterColumn("dbo.Students", "ChurchId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "PriestId", newName: "Priest_Id");
            RenameColumn(table: "dbo.Students", name: "ChurchId", newName: "Church_Id");
            CreateIndex("dbo.Students", "Priest_Id");
            CreateIndex("dbo.Students", "Church_Id");
            AddForeignKey("dbo.Students", "Priest_Id", "dbo.Priests", "Id");
            AddForeignKey("dbo.Students", "Church_Id", "dbo.Churches", "Id");
        }
    }
}
