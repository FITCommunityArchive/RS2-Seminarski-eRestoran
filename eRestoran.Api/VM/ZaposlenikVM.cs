using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eRestoran.Api.VM
{
    public class ZaposlenikVM
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string JMBG { get; set; }
        public string Telefon { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public string Adresa { get; set; }
        public double Plata { get; set; }
        public StatusZaposlenika Status { get; set; }
        public string Password { get; set; }
    }
}