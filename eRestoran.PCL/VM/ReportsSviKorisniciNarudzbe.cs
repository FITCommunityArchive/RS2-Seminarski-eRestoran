using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class ReportsSviKorisniciNarudzbe
    {
        public List<KorisnikInfo> Zaposlenici { get; set; }
        public List<KorisnikInfo> Klijenti { get; set; }
    }

    public class KorisnikInfo
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public int BrojNarudzbi { get; set; }
        public double Iznos { get; set; }
    }
}