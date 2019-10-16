using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Data.Models
{
   [Table("Klijents")]
    public class Klijent : Korisnik
    {
        public Klijent()
        {
            this.NarudzbaRacun = new HashSet<NarudzbaRacun>();
            this.Rezervacija = new HashSet<Rezervacija>();
            this.Ocjene = new HashSet<Ocjene>();

        }

        public virtual ICollection<NarudzbaRacun> NarudzbaRacun { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Ocjene> Ocjene { get; set; }


    }
}