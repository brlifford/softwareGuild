namespace DvdLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DirectorId);

            CreateTable(
                "dbo.Dvds",
                c => new
                {
                    DvdId = c.Int(nullable: false, identity: true),
                    Title = c.String(maxLength: 50),
                    DirectorId = c.Int(nullable: false),
                    ReleaseDate = c.DateTime(nullable: false),
                    RatingId = c.Int(nullable: false),
                    DvdNotes = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.Directors", t => t.DirectorId, cascadeDelete: false)
                .ForeignKey("dbo.Ratings", t => t.RatingId, cascadeDelete: false)
                .Index(t => t.DirectorId)
                .Index(t => t.RatingId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.Dvds", "DirectorId", "dbo.Directors");
            DropIndex("dbo.Dvds", new[] { "RatingId" });
            DropIndex("dbo.Dvds", new[] { "DirectorId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Dvds");
            DropTable("dbo.Directors");
        }
    }
}
