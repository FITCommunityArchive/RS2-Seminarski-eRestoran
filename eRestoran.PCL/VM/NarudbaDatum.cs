using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class NarudbaDatum
    {
        public class NarudzbaRow {
            public int NarudzbaId { get; set; }
            public DateTime Datum { get; set; }
            public string KlijentIme  { get; set; }
            public double Iznos  { get; set; }
            public int? KlijentId { get; set; }
        }
        public List<NarudzbaRow> Narudzbe { get; set; }

    }
}