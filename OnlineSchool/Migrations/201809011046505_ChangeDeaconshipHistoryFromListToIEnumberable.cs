namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDeaconshipHistoryFromListToIEnumberable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeaconshipHistories", "Student_Id", "dbo.Students");
            DropIndex("dbo.DeaconshipHistories", new[] { "Student_Id" });
            DropColumn("dbo.DeaconshipHistories", "Student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeaconshipHistories", "Student_Id", c => c.Int());
            CreateIndex("dbo.DeaconshipHistories", "Student_Id");
            AddForeignKey("dbo.DeaconshipHistories", "Student_Id", "dbo.Students", "Id");
        }
    }
}
