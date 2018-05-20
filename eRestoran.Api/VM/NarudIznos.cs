using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class NarudIznos
    {
        public class IznosRow {
            public int NarudzbaId { get; set; }
            public double Iznos { get; set; }
            public DateTime Datum { get; set; }
            public string KlijentIme { get; set; }
        }
        public List<IznosRow> Iznosi { get; set; }
    }
}