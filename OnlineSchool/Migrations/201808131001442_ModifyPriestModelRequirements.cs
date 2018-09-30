namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPriestModelRequirements : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Priests", new[] { "church_Id" });
            AlterColumn("dbo.Priests", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Priests", "Church_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Priests", new[] { "Church_Id" });
            AlterColumn("dbo.Priests", "Name", c => c.String());
            CreateIndex("dbo.Priests", "church_Id");
        }
    }
}
