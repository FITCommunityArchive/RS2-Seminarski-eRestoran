using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Data.Models
{
    public class Proizvod
    {
        public Proizvod()
        {
            this.JelaStavke = new HashSet<JelaStavke>();
            this.NarudzbaStavke = new HashSet<NarudzbaStavke>();
            this.HistorijaCijenaProizvoda = new HashSet<HistorijaCijenaProizvoda>();
        }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Kolicina { get; set;  }
        public double Cijena { get; set; }
        public string Sifra { get; set; }
        public string Menu { get; set; }
        public int KriticnaKolicina { get; set; }
        public int TipProizvodaId { get; set; }
        public int SkladisteId { get; set; }
        
        
        
        public virtual TipProizvoda TipProizvoda { get; set; }
        public virtual Skladiste Skladiste { get; set; }

        public virtual ICollection<JelaStavke> JelaStavke { get; set; }
        public virtual ICollection<HistorijaCijenaProizvoda> HistorijaCijenaProizvoda { get; set; }
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
    }
}