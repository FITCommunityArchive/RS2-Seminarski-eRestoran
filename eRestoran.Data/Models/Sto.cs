using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eRestoran.Data.Models
{
    public class Sto
    {
        public Sto()
        {
            this.Rezervacija = new HashSet<Rezervacija>();
            this.Narudzba = new HashSet<Narudzba>();
        }
        [Key, ForeignKey("Narudzba")]
        public int Id{get; set;}
        public int RedniBroj { get; set; }
        public bool IsSlobodan { get; set; }
        
      
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Narudzba> Narudzba { get; set; }

    }
}