using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class ReportsNarudzbeDanVM
    {
        public List<ReportsNarudzbeDanRow> ZaposlenikNarudzbe { get; set; }
        public List<ReportsNarudzbeDanRow> KlijentNarudzbe { get; set; }
        public string Datum { get; set; }
    }
    public class ReportsNarudzbeDanRow
    {
        public int? Id { get; set; }
        public string Ime { get; set; }
        public int BrojNarudzbi { get; set; }
        public double IznosNarudzbi { get; set; }
    }
}