using System;
namespace eRestoran.PCL.VM
{
    public enum TipKorisnika
    {
        Admin, Menadzer, Klijent, Konobar, Kuhar, Sanker
    }
    public enum StatusZaposlenika
    {
        Aktivan, Godisnji, Otpusten
    }
    public class NoviZaposlenik
    {
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string Adresa { get; set; }
        public string Jmbg { get; set; }
        public double Plata { get; set; }
        public StatusZaposlenika Status { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DatumPrijave { get; set; }
        public TipKorisnika TipKorisnika { get; set; }

        public string Email { get; set; }
    }
}