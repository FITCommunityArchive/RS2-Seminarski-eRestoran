using System;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Data.Models
{
    public class Promocija
    {
        [Key]
        public int Id { get; set; }

        public DateTime DatumOd { get; set; }

        public DateTime DatumDo { get; set; }

        public double StaraCijena { get; set; }

        public double PromotivnaCijena { get; set; }

        public int? JeloId { get; set; }

        public virtual Jelo Jelo { get; set; }

        public int? ProizvodId { get; set; }

        public virtual Proizvod Proizvod { get; set; }
    }
}
