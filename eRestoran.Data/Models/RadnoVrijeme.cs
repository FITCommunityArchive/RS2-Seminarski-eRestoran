using System;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Data.Models
{
     public class RadnoVrijeme
    {
         [Key]
        public int Id { get; set; }
        public DateTime DatumOdjave { get; set; }
        public double Radnovrijeme { get; set; }
        public int ZaposlenikId { get; set; }
        public int ObracunskiMjesecId { get; set; }

        public virtual Zaposlenik Zaposlenik { get; set; }
        public virtual ObracunskiMjesec ObracunskiMjesec { get; set; }
    }
}
