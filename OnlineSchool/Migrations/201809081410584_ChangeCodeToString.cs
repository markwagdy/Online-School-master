namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCodeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servants", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.DeaconshipHistories", "UserCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DeaconshipHistories", "UserCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Code", c => c.Int(nullable: false));
            AlterColumn("dbo.Servants", "Code", c => c.Int(nullable: false));
        }
    }
}
