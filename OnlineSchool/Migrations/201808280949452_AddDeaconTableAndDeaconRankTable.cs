namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeaconTableAndDeaconRankTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deacons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deacons", t => t.Deacon_Id)
                .Index(t => t.Deacon_Id);
            
            AddColumn("dbo.Students", "Deacon_Id", c => c.Int());
            CreateIndex("dbo.Students", "Deacon_Id");
            AddForeignKey("dbo.Students", "Deacon_Id", "dbo.Deacons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Deacon_Id", "dbo.Deacons");
            DropForeignKey("dbo.DeaconRanks", "Deacon_Id", "dbo.Deacons");
            DropIndex("dbo.DeaconRanks", new[] { "Deacon_Id" });
            DropIndex("dbo.Students", new[] { "Deacon_Id" });
            DropColumn("dbo.Students", "Deacon_Id");
            DropTable("dbo.DeaconRanks");
            DropTable("dbo.Deacons");
        }
    }
}
