using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Data.Models
{
    public enum statusNarudzbe
    {
        U_Pripremi, Spremna, Preuzeta
        }
    public class Narudzba
    {
        public Narudzba()
        {
            this.NarudzbaStavke = new HashSet<NarudzbaStavke>();
        }
        public int Id{get; set;}
        public string Sifra { get; set; }
        public int? StoId { get; set; }
        public int? ZaposlenikId { get; set; }
        public int? KlijentId { get; set; }
        public virtual Klijent Klijent { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }
        public statusNarudzbe StatusJela { get; set; }
        public statusNarudzbe StatusPica { get; set; }
        public virtual Sto Sto { get; set; }
        public virtual NarudzbaRacun NarudzbaRacun { get; set; }
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
        
    }
}