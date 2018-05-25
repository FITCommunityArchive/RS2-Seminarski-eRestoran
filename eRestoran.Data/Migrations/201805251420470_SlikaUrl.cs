namespace eRestoran.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlikaUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jeloes", "SlikaUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jeloes", "SlikaUrl");
        }
    }
}
