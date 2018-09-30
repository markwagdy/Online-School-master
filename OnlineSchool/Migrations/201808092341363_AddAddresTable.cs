namespace OnlineSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddresTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Students", new[] { "church_Id" });
            DropIndex("dbo.Students", new[] { "priest_Id" });
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Apartment = c.String(),
                        Building = c.String(),
                        Street = c.String(),
                        District = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "MaritalStatus", c => c.String());
            AddColumn("dbo.Students", "Address_Id", c => c.Int());
            CreateIndex("dbo.Students", "Address_Id");
            CreateIndex("dbo.Students", "Church_Id");
            CreateIndex("dbo.Students", "Priest_Id");
            AddForeignKey("dbo.Students", "Address_Id", "dbo.Addresses", "Id");
            DropColumn("dbo.Students", "Address");
            DropColumn("dbo.Students", "MartialState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "MartialState", c => c.String());
            AddColumn("dbo.Students", "Address", c => c.String());
            DropForeignKey("dbo.Students", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Students", new[] { "Priest_Id" });
            DropIndex("dbo.Students", new[] { "Church_Id" });
            DropIndex("dbo.Students", new[] { "Address_Id" });
            DropColumn("dbo.Students", "Address_Id");
            DropColumn("dbo.Students", "MaritalStatus");
            DropTable("dbo.Addresses");
            CreateIndex("dbo.Students", "priest_Id");
            CreateIndex("dbo.Students", "church_Id");
        }
    }
}
