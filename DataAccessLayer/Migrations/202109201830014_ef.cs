namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ef : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        AboutDetailOne = c.String(),
                        AboutDetailTwo = c.String(),
                        AboutImage1 = c.String(),
                        AboutImage2 = c.String(),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDescription = c.String(),
                        CategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingId = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(),
                        HeadingDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(),
                        ContentDate = c.DateTime(nullable: false),
                        HeadingId = c.Int(nullable: false),
                        WriterId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.Headings", t => t.HeadingId, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterId)
                .Index(t => t.HeadingId)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterId = c.Int(nullable: false, identity: true),
                        WriterName = c.String(),
                        WriterSurname = c.String(),
                        WriterImage = c.String(),
                        WriterMail = c.String(),
                        WriterPassword = c.String(),
                    })
                .PrimaryKey(t => t.WriterId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserMail = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Contents", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Contents", "HeadingId", "dbo.Headings");
            DropForeignKey("dbo.Headings", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "WriterId" });
            DropIndex("dbo.Contents", new[] { "HeadingId" });
            DropIndex("dbo.Headings", new[] { "WriterId" });
            DropIndex("dbo.Headings", new[] { "CategoryId" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Writers");
            DropTable("dbo.Contents");
            DropTable("dbo.Headings");
            DropTable("dbo.Categories");
            DropTable("dbo.Abouts");
        }
    }
}
