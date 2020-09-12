namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Works", "DT", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Works", "DT");
        }
    }
}
