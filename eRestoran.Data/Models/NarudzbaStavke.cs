using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eRestoran.Data.Models
{
    public class NarudzbaStavke
    {
        
        [Key]
        public int Id { get; set; }

        public int NarudzbaId { get; set; }
        public int? ProizvodId { get; set; }
        public int? JeloId { get; set; }
        public int Kolicina { get; set; }

        public virtual Proizvod Proizvod { get; set; }
        public virtual Jelo Jelo { get; set; }
        public virtual Narudzba Narudzba { get; set; }
    }
}