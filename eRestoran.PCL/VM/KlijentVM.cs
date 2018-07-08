using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.PCL.VM
{
    public class KlijentVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int Id { get; set; }
        public string Email { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public string Adresa { get; set; }
        public double Plata { get; set; }
    }
}