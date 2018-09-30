namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDeaconTableAndAddUserIdColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeaconRanks", "Deacon_Id", "dbo.Deacons");
            DropForeignKey("dbo.Students", "Deacon_Id", "dbo.Deacons");
            DropIndex("dbo.Students", new[] { "Deacon_Id" });
            DropIndex("dbo.DeaconRanks", new[] { "Deacon_Id" });
            AddColumn("dbo.Students", "IsDeacon", c => c.Boolean(nullable: false));
            DropColumn("dbo.Students", "Deacon_Id");
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DeaconRanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.String(),
                        AssignName = c.String(),
                        AssignTime = c.DateTime(nullable: false),
                        Bishop = c.String(),
                        AssignPlace = c.String(),
                        Deacon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deacons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "Deacon_Id", c => c.Int());
            DropColumn("dbo.Students", "IsDeacon");
            CreateIndex("dbo.DeaconRanks", "Deacon_Id");
            CreateIndex("dbo.Students", "Deacon_Id");
            AddForeignKey("dbo.Students", "Deacon_Id", "dbo.Deacons", "Id");
            AddForeignKey("dbo.DeaconRanks", "Deacon_Id", "dbo.Deacons", "Id");
        }
    }
}
