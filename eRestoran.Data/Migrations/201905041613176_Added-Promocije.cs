namespace eRestoran.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPromocije : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                       "dbo.Promocijas",
                       c => new
                       {
                           Id = c.Int(nullable: false, identity: true),
                           DatumOd = c.DateTime(nullable: false),
                           DatumDo = c.DateTime(nullable: false),
                           StaraCijena = c.Double(nullable: false),
                           PromotivnaCijena = c.Double(nullable: false),
                           JeloId = c.Int(),
                           ProizvodId = c.Int(),
                       })
                       .PrimaryKey(t => t.Id)
                       .ForeignKey("dbo.Jeloes", t => t.JeloId)
                       .ForeignKey("dbo.Proizvods", t => t.ProizvodId)
                       .Index(t => t.JeloId)
                       .Index(t => t.ProizvodId);

        }
        
        public override void Down()
        {
        
        }
    }
}
