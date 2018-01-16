using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestoran.Data.Models
{
    public class JelaStavke
    {
        
        [Key]
        [Column(Order = 1)]
        public int JeloId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProizvodId { get; set; }
        public virtual Jelo Jelo { get; set; }
        public virtual Proizvod Proizvod { get; set; }

        public int Kolicina { get; set; }
    }
}