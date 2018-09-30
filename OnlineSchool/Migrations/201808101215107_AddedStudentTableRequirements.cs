namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudentTableRequirements : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Students", new[] { "Address_Id" });
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "AcademicYear", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "MobileNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "HomeNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "MaritalStatus", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Job", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Address_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Address_Id");
            AddForeignKey("dbo.Students", "Address_Id", "dbo.Addresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Students", new[] { "Address_Id" });
            AlterColumn("dbo.Students", "Address_Id", c => c.Int());
            AlterColumn("dbo.Students", "Job", c => c.String());
            AlterColumn("dbo.Students", "MaritalStatus", c => c.String());
            AlterColumn("dbo.Students", "HomeNumber", c => c.String());
            AlterColumn("dbo.Students", "MobileNumber", c => c.String());
            AlterColumn("dbo.Students", "AcademicYear", c => c.String());
            AlterColumn("dbo.Students", "Gender", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            CreateIndex("dbo.Students", "Address_Id");
            AddForeignKey("dbo.Students", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
