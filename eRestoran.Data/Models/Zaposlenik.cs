using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace eRestoran.Data.Models
{
    public enum StatusZaposlenika
    {
        Aktivan,Godisnji,Otpusten
    }
    [Table("Zaposleniks")]
    public class Zaposlenik : Korisnik
    {
        public Zaposlenik() 
        {
            this.Narudzba = new HashSet<Narudzba>();
            this.RadnoVrijeme = new HashSet<RadnoVrijeme>();
        }

        [Required]
        public DateTime DatumRodjenja { get; set; }
         [Required]
        public DateTime DatumZaposlenja { get; set; }
         [Required]
        public string Adresa { get; set; }
        [Required]
        public string Jmbg { get; set; }
        public double Plata { get; set; }
        public StatusZaposlenika Status { get; set; }

        public virtual ICollection<Narudzba> Narudzba { get; set; }
        public virtual ICollection<RadnoVrijeme> RadnoVrijeme { get; set; }
    }
}