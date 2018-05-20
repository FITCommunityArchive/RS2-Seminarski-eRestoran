using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class ReportsNarudzbeKorisnika
    {
        public string Ime { get; set; }
        public string Datum { get; set; }
        public List<ReportsNarudzbeKorisnikaRow> Narudzbe { get; set; }
    }
    public class ReportsNarudzbeKorisnikaRow
    {
        public int NarudzbaId { get; set; }
        public List<ProizvodInfo> Proizvodi { get; set; }
    }
    public class ProizvodInfo
    {
        public int NarudzbaId { get; set; }
        public string NazivProizvoda { get; set; }
        public int KolicinaProizvoda { get; set; }
        public double IznosProizvoda { get; set; }
        public string VrijemeNarudzbe { get; set; }
    }
}