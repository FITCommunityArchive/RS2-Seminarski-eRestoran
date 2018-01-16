using System;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Data.Models
{
    public class HistorijaCijenaProizvoda
    {
        [Key]
        public int Id { get; set; }

        public DateTime Datum { get; set; }
        public double StaraCijena { get; set; }
        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }

    }
}