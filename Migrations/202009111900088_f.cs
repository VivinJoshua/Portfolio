namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Works", "filter_Id", "dbo.filters");
            DropIndex("dbo.Works", new[] { "filter_Id" });
            DropColumn("dbo.Works", "filter_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Works", "filter_Id", c => c.Int());
            CreateIndex("dbo.Works", "filter_Id");
            AddForeignKey("dbo.Works", "filter_Id", "dbo.filters", "Id");
        }
    }
}
