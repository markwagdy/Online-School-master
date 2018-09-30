namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlToStudentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ImagePath");
        }
    }
}
