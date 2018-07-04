namespace eRestoran.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistorijaCijenaJelas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        StaraCijena = c.Double(nullable: false),
                        JeloId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jeloes", t => t.JeloId, cascadeDelete: true)
                .Index(t => t.JeloId);
            
            CreateTable(
                "dbo.Jeloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Cijena = c.Double(nullable: false),
                        Sifra = c.String(nullable: false),
                        Menu = c.String(),
                        SlikaUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JelaStavkes",
                c => new
                    {
                        JeloId = c.Int(nullable: false),
                        ProizvodId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JeloId, t.ProizvodId })
                .ForeignKey("dbo.Jeloes", t => t.JeloId, cascadeDelete: true)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodId, cascadeDelete: true)
                .Index(t => t.JeloId)
                .Index(t => t.ProizvodId);
            
            CreateTable(
                "dbo.Proizvods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Kolicina = c.Int(nullable: false),
                        Cijena = c.Double(nullable: false),
                        Sifra = c.String(),
                        Menu = c.String(),
                        KriticnaKolicina = c.Int(nullable: false),
                        TipProizvodaId = c.Int(nullable: false),
                        SkladisteId = c.Int(nullable: false),
                        SlikaUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skladistes", t => t.SkladisteId, cascadeDelete: true)
                .ForeignKey("dbo.TipProizvodas", t => t.TipProizvodaId, cascadeDelete: true)
                .Index(t => t.TipProizvodaId)
                .Index(t => t.SkladisteId);
            
            CreateTable(
                "dbo.HistorijaCijenaProizvodas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        StaraCijena = c.Double(nullable: false),
                        ProizvodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodId, cascadeDelete: true)
                .Index(t => t.ProizvodId);
            
            CreateTable(
                "dbo.NarudzbaStavkes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NarudzbaId = c.Int(nullable: false),
                        ProizvodId = c.Int(),
                        JeloId = c.Int(),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jeloes", t => t.JeloId)
                .ForeignKey("dbo.Narudzbas", t => t.NarudzbaId, cascadeDelete: true)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodId)
                .Index(t => t.NarudzbaId)
                .Index(t => t.ProizvodId)
                .Index(t => t.JeloId);
            
            CreateTable(
                "dbo.Narudzbas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sifra = c.String(),
                        StoId = c.Int(),
                        ZaposlenikId = c.Int(),
                        KlijentId = c.Int(),
                        StatusJela = c.Int(nullable: false),
                        StatusPica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .ForeignKey("dbo.Stoes", t => t.StoId)
                .ForeignKey("dbo.Klijents", t => t.KlijentId)
                .Index(t => t.StoId)
                .Index(t => t.ZaposlenikId)
                .Index(t => t.KlijentId);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        Username = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false),
                        DatumPrijave = c.DateTime(nullable: false),
                        TipKorisnika = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NarudzbaRacuns",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DatumIzdavanja = c.DateTime(nullable: false),
                        Iznos = c.Double(nullable: false),
                        Sifra = c.String(nullable: false),
                        ZaposlenikId = c.Int(),
                        KlijentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Klijents", t => t.KlijentId)
                .ForeignKey("dbo.Narudzbas", t => t.Id)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.Id)
                .Index(t => t.ZaposlenikId)
                .Index(t => t.KlijentId);
            
            CreateTable(
                "dbo.RadnoVrijemes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumOdjave = c.DateTime(nullable: false),
                        Radnovrijeme = c.Double(nullable: false),
                        ZaposlenikId = c.Int(nullable: false),
                        ObracunskiMjesecId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObracunskiMjesecs", t => t.ObracunskiMjesecId, cascadeDelete: true)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.ZaposlenikId)
                .Index(t => t.ObracunskiMjesecId);
            
            CreateTable(
                "dbo.ObracunskiMjesecs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Godina = c.Int(nullable: false),
                        Mjesec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rezervacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        datumVrijemeOd = c.DateTime(nullable: false),
                        datumVrijemeDo = c.DateTime(nullable: false),
                        KlijentId = c.Int(nullable: false),
                        StoId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Klijents", t => t.KlijentId)
                .ForeignKey("dbo.Stoes", t => t.StoId, cascadeDelete: true)
                .Index(t => t.KlijentId)
                .Index(t => t.StoId);
            
            CreateTable(
                "dbo.Stoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RedniBroj = c.Int(nullable: false),
                        IsSlobodan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skladistes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adresa = c.String(),
                        Kvadratura = c.String(),
                        TipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipSkladistas", t => t.TipId, cascadeDelete: true)
                .Index(t => t.TipId);
            
            CreateTable(
                "dbo.TipSkladistas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipProizvodas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        MjernaJedinica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Klijents",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Zaposleniks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DatumRodjenja = c.DateTime(nullable: false),
                        DatumZaposlenja = c.DateTime(nullable: false),
                        Adresa = c.String(nullable: false),
                        Jmbg = c.String(nullable: false),
                        Plata = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zaposleniks", "Id", "dbo.Korisniks");
            DropForeignKey("dbo.Klijents", "Id", "dbo.Korisniks");
            DropForeignKey("dbo.Proizvods", "TipProizvodaId", "dbo.TipProizvodas");
            DropForeignKey("dbo.Skladistes", "TipId", "dbo.TipSkladistas");
            DropForeignKey("dbo.Proizvods", "SkladisteId", "dbo.Skladistes");
            DropForeignKey("dbo.NarudzbaStavkes", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.NarudzbaStavkes", "NarudzbaId", "dbo.Narudzbas");
            DropForeignKey("dbo.Narudzbas", "KlijentId", "dbo.Klijents");
            DropForeignKey("dbo.Rezervacijas", "StoId", "dbo.Stoes");
            DropForeignKey("dbo.Narudzbas", "StoId", "dbo.Stoes");
            DropForeignKey("dbo.Rezervacijas", "KlijentId", "dbo.Klijents");
            DropForeignKey("dbo.NarudzbaRacuns", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.RadnoVrijemes", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.RadnoVrijemes", "ObracunskiMjesecId", "dbo.ObracunskiMjesecs");
            DropForeignKey("dbo.Narudzbas", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.NarudzbaRacuns", "Id", "dbo.Narudzbas");
            DropForeignKey("dbo.NarudzbaRacuns", "KlijentId", "dbo.Klijents");
            DropForeignKey("dbo.NarudzbaStavkes", "JeloId", "dbo.Jeloes");
            DropForeignKey("dbo.JelaStavkes", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.HistorijaCijenaProizvodas", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.JelaStavkes", "JeloId", "dbo.Jeloes");
            DropForeignKey("dbo.HistorijaCijenaJelas", "JeloId", "dbo.Jeloes");
            DropIndex("dbo.Zaposleniks", new[] { "Id" });
            DropIndex("dbo.Klijents", new[] { "Id" });
            DropIndex("dbo.Skladistes", new[] { "TipId" });
            DropIndex("dbo.Rezervacijas", new[] { "StoId" });
            DropIndex("dbo.Rezervacijas", new[] { "KlijentId" });
            DropIndex("dbo.RadnoVrijemes", new[] { "ObracunskiMjesecId" });
            DropIndex("dbo.RadnoVrijemes", new[] { "ZaposlenikId" });
            DropIndex("dbo.NarudzbaRacuns", new[] { "KlijentId" });
            DropIndex("dbo.NarudzbaRacuns", new[] { "ZaposlenikId" });
            DropIndex("dbo.NarudzbaRacuns", new[] { "Id" });
            DropIndex("dbo.Narudzbas", new[] { "KlijentId" });
            DropIndex("dbo.Narudzbas", new[] { "ZaposlenikId" });
            DropIndex("dbo.Narudzbas", new[] { "StoId" });
            DropIndex("dbo.NarudzbaStavkes", new[] { "JeloId" });
            DropIndex("dbo.NarudzbaStavkes", new[] { "ProizvodId" });
            DropIndex("dbo.NarudzbaStavkes", new[] { "NarudzbaId" });
            DropIndex("dbo.HistorijaCijenaProizvodas", new[] { "ProizvodId" });
            DropIndex("dbo.Proizvods", new[] { "SkladisteId" });
            DropIndex("dbo.Proizvods", new[] { "TipProizvodaId" });
            DropIndex("dbo.JelaStavkes", new[] { "ProizvodId" });
            DropIndex("dbo.JelaStavkes", new[] { "JeloId" });
            DropIndex("dbo.HistorijaCijenaJelas", new[] { "JeloId" });
            DropTable("dbo.Zaposleniks");
            DropTable("dbo.Klijents");
            DropTable("dbo.TipProizvodas");
            DropTable("dbo.TipSkladistas");
            DropTable("dbo.Skladistes");
            DropTable("dbo.Stoes");
            DropTable("dbo.Rezervacijas");
            DropTable("dbo.ObracunskiMjesecs");
            DropTable("dbo.RadnoVrijemes");
            DropTable("dbo.NarudzbaRacuns");
            DropTable("dbo.Korisniks");
            DropTable("dbo.Narudzbas");
            DropTable("dbo.NarudzbaStavkes");
            DropTable("dbo.HistorijaCijenaProizvodas");
            DropTable("dbo.Proizvods");
            DropTable("dbo.JelaStavkes");
            DropTable("dbo.Jeloes");
            DropTable("dbo.HistorijaCijenaJelas");
        }
    }
}
