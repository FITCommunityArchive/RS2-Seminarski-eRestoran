using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class ReportsNarduzbeVM
    {
        public List<ReportsNarudzbeRow> Narudzbe { get; set; }
        

    }
    public class ReportsNarudzbeRow
    {
        public string Datum { get; set; }
        public int BrojNarudzbi { get; set; }
        public double UkupnaCijena { get; set; }
        public double ProsjecnaCijena { get; set; }
    }
}