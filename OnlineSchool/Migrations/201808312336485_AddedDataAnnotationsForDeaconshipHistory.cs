namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotationsForDeaconshipHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeaconshipHistories", "UserCode", c => c.Int(nullable: false));
            AlterColumn("dbo.DeaconshipHistories", "AssignTime", c => c.DateTime());
            DropColumn("dbo.DeaconshipHistories", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeaconshipHistories", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.DeaconshipHistories", "AssignTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.DeaconshipHistories", "UserCode");
        }
    }
}
