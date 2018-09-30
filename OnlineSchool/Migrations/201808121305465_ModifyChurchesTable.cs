namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyChurchesTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Churches", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Churches", "Name", c => c.String());
        }
    }
}
