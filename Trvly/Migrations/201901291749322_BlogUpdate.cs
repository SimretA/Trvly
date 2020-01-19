namespace Trvly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPosts", "PostedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "PostedBy_Id" });
            AddColumn("dbo.BlogPosts", "PostedBy", c => c.String());
            DropColumn("dbo.BlogPosts", "PostedBy_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogPosts", "PostedBy_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.BlogPosts", "PostedBy");
            CreateIndex("dbo.BlogPosts", "PostedBy_Id");
            AddForeignKey("dbo.BlogPosts", "PostedBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
