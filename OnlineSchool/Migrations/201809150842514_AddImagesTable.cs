namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "StudentCard_Id", c => c.Int());
            CreateIndex("dbo.Students", "StudentCard_Id");
            AddForeignKey("dbo.Students", "StudentCard_Id", "dbo.Images", "Id");
            DropColumn("dbo.Students", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ImagePath", c => c.String());
            DropForeignKey("dbo.Students", "StudentCard_Id", "dbo.Images");
            DropIndex("dbo.Students", new[] { "StudentCard_Id" });
            DropColumn("dbo.Students", "StudentCard_Id");
            DropTable("dbo.Images");
        }
    }
}
