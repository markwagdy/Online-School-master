namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLessonTypeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "Servant_Id", "dbo.Servants");
            DropIndex("dbo.Classes", new[] { "Servant_Id" });
            AddColumn("dbo.Servants", "Email", c => c.String());
            AddColumn("dbo.Servants", "Class_Id", c => c.Int());
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "MotherName", c => c.String());
            CreateIndex("dbo.Servants", "Class_Id");
            AddForeignKey("dbo.Servants", "Class_Id", "dbo.Classes", "Id");
            DropColumn("dbo.Classes", "Servant_Id");
            DropColumn("dbo.Lessons", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Type", c => c.String());
            AddColumn("dbo.Classes", "Servant_Id", c => c.Int());
            DropForeignKey("dbo.Servants", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Servants", new[] { "Class_Id" });
            DropColumn("dbo.Students", "MotherName");
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Servants", "Class_Id");
            DropColumn("dbo.Servants", "Email");
            CreateIndex("dbo.Classes", "Servant_Id");
            AddForeignKey("dbo.Classes", "Servant_Id", "dbo.Servants", "Id");
        }
    }
}
