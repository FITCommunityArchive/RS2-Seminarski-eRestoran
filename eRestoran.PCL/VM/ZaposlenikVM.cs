using eRestoran.Data.Models;
using System;

namespace eRestoran.PCL.VM
{
    public class ZaposlenikVM
    {
        
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string JMBG { get; set; }
        public string Telefon { get; set; }
        public string Username { get; set; }
        
        public int Id { get; set; }
        public string Email { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public string Adresa { get; set; }
        public double Plata { get; set; }
        public StatusZaposlenika Status { get; set; }
        public string Password { get; set; }
    }
}