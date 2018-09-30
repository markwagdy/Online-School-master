namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyServantTableMembers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servants", "Code", c => c.Int(nullable: false));
            AlterColumn("dbo.Servants", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Servants", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servants", "Email", c => c.String());
            AlterColumn("dbo.Servants", "Name", c => c.String());
            DropColumn("dbo.Servants", "Code");
        }
    }
}
