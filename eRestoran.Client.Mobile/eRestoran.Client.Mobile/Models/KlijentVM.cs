using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Client.Mobile.Models
{
    public enum TipKorisnika
    {
        Admin, Menadzer, Klijent, Konobar, Kuhar, Sanker
    }
    public class KlijentVM
    {
    
        public int Id { get; set; }  
        public string Ime { get; set; }    
        public string Prezime { get; set; }   
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DatumPrijave { get; set; }
        public TipKorisnika TipKorisnika { get; set; }

        public string Email { get; set; }
    }
}
