namespace eRestoran.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createOcjene : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ocjenes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProizvodId = c.Int(nullable: false),
                        KupacId = c.Int(nullable: false),
                        Ocjena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Klijents", t => t.KupacId)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodId, cascadeDelete: true)
                .Index(t => t.ProizvodId)
                .Index(t => t.KupacId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ocjenes", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.Ocjenes", "KupacId", "dbo.Klijents");
            DropIndex("dbo.Ocjenes", new[] { "KupacId" });
            DropIndex("dbo.Ocjenes", new[] { "ProizvodId" });
            DropTable("dbo.Ocjenes");
        }
    }
}
