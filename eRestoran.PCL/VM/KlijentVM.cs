using eRestoran.Data.Models;
using System;

namespace eRestoran.PCL.VM
{
    public enum TipKorisnikaVM
    {
        Admin, Menadzer, Klijent, Konobar, Kuhar, Sanker
    }
    public class KlijentVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int Id { get; set; }
        public string Email { get; set; }
        public int TipKorisnika { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumPrijave { get; set; }

    }
}