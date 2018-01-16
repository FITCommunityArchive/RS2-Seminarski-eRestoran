using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eRestoran.Data.Models
{
    public enum TipKorisnika
    {
        Admin, Menadzer, Klijent, Konobar, Kuhar, Sanker
    }
    public abstract class Korisnik
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        [StringLength(150)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime DatumPrijave { get; set; }
        public TipKorisnika TipKorisnika { get; set; }

        public string Email { get; set; }

    }
}