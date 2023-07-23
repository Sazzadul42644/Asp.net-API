namespace APITask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CatID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        date = c.DateTime(nullable: false),
                        CatID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CatID, cascadeDelete: true)
                .Index(t => t.CatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "CatID", "dbo.Categories");
            DropIndex("dbo.News", new[] { "CatID" });
            DropTable("dbo.News");
            DropTable("dbo.Categories");
        }
    }
}
