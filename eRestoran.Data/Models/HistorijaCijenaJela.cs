using System;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Data.Models
{
    public class HistorijaCijenaJela
    {
        [Key]
        public int Id { get; set; }

        public DateTime Datum { get; set; }
        public double StaraCijena { get; set; }
        public int JeloId { get; set; }
        public virtual Jelo Jelo { get; set; }
    }
}