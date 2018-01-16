using System.Collections.Generic;
using eRestoran.Data.Models;
using System.Data.Entity;

namespace eRestoran.Data.DAL
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyKonekcija")
        {

        }
        public DbSet<Sto> Stolovi { get; set; }
        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
   
        public DbSet<HistorijaCijenaJela> HistorijaCijenaJela { get; set; }
        public DbSet<HistorijaCijenaProizvoda> HistorijaCijenaProizvoda { get; set; }
        public DbSet<JelaStavke> JelaStavke { get; set; }
        public DbSet<Jelo> Jelo { get; set; }
      
        public DbSet<NarudzbaRacun> Racuni { get; set; }
        public DbSet<NarudzbaStavke> NarudzbaStavke { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Skladiste> Skladista { get; set; }
        public DbSet<TipSkladista> TipoviSkladista { get; set; }
        public DbSet<TipProizvoda> TipoviProizvoda { get; set; }
        
        public DbSet<RadnoVrijeme> RadnoVrijeme { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<ObracunskiMjesec> ObracunskiMjesec { get; set; }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           

        }

    }
}