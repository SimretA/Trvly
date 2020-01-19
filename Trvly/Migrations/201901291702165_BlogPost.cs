namespace Trvly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        PostedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.PostedBy_Id)
                .Index(t => t.PostedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "PostedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "PostedBy_Id" });
            DropTable("dbo.BlogPosts");
        }
    }
}
