using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eRestoran.Data.Models
{
    public class NarudzbaRacun
    {
        [Key, ForeignKey("Narudzba")]
        public int Id { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public double Iznos { get; set; }
        [Required]
        public string Sifra { get; set; }
        public int? ZaposlenikId { get; set; }
        public int? KlijentId { get; set; }

        public virtual Zaposlenik Zaposlenik { get; set; }
        public virtual Klijent Klijent { get; set; }
        public virtual Narudzba Narudzba { get; set; }
    }
}