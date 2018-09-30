namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SplitLeveltoYearAndTerm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "Year", c => c.String());
            AddColumn("dbo.Lessons", "Term", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "Term");
            DropColumn("dbo.Lessons", "Year");
        }
    }
}
