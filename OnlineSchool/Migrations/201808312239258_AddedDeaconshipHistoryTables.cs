namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDeaconshipHistoryTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeaconshipHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.String(),
                        AssignName = c.String(),
                        AssignTime = c.DateTime(nullable: false),
                        AssignPlace = c.String(),
                        Bishop = c.String(),
                        UserId = c.Int(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeaconshipHistories", "Student_Id", "dbo.Students");
            DropIndex("dbo.DeaconshipHistories", new[] { "Student_Id" });
            DropTable("dbo.DeaconshipHistories");
        }
    }
}
