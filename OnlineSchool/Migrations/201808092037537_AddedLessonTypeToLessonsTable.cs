namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLessonTypeToLessonsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LessonTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lessons", "Type_Id", c => c.Int());
            CreateIndex("dbo.Lessons", "Type_Id");
            AddForeignKey("dbo.Lessons", "Type_Id", "dbo.LessonTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "Type_Id", "dbo.LessonTypes");
            DropIndex("dbo.Lessons", new[] { "Type_Id" });
            DropColumn("dbo.Lessons", "Type_Id");
            DropTable("dbo.LessonTypes");
        }
    }
}
