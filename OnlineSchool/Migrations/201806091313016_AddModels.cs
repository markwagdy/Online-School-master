namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Churches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Priests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OfficeNumber = c.String(),
                        MobileNumber = c.String(),
                        church_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.church_Id)
                .Index(t => t.church_Id);
            
            CreateTable(
                "dbo.Servants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        BirtDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        AcademicYear = c.String(),
                        MobileNumber = c.String(),
                        HomeNumber = c.String(),
                        Address = c.String(),
                        MartialState = c.String(),
                        Job = c.String(),
                        FatherPhone = c.String(),
                        MotherPhone = c.String(),
                        church_Id = c.Int(),
                        priest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.church_Id)
                .ForeignKey("dbo.Priests", t => t.priest_Id)
                .Index(t => t.church_Id)
                .Index(t => t.priest_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "priest_Id", "dbo.Priests");
            DropForeignKey("dbo.Students", "church_Id", "dbo.Churches");
            DropForeignKey("dbo.Priests", "church_Id", "dbo.Churches");
            DropIndex("dbo.Students", new[] { "priest_Id" });
            DropIndex("dbo.Students", new[] { "church_Id" });
            DropIndex("dbo.Priests", new[] { "church_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Servants");
            DropTable("dbo.Priests");
            DropTable("dbo.Churches");
        }
    }
}
