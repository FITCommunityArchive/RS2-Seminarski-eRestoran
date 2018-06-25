using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class ReportsSveNarudzbeKorisnika
    {
        public string Ime { get; set; }
        
        public List<ReportsSveNarudzbeKorisnikaRow> Narudzbe { get; set; }
    }
    public class ReportsSveNarudzbeKorisnikaRow
    {
        public int NarudzbaId { get; set; }
        public string Datum { get; set; }
        public double UkupniIznos { get; set; }
        public int UkupnaKolicina { get; set; }
        public List<ProizvodInfo> Proizvodi { get; set; }
    }

}