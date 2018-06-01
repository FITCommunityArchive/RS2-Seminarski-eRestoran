namespace eRestoran.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanIsDeletedtorezervacije : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rezervacijas", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rezervacijas", "IsDeleted");
        }
    }
}
