namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.filters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Filter = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.filters");
        }
    }
}
