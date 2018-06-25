using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class NarudzbaPonuda
    {
        public class ROW {

            public int Id { get; set; }
            public DateTime? Datum { get; set; }
            public double? Iznos { get; set; }
            public int? KlijentId { get; set; }
            public string  KlijentIme { get; set; }
            public string ZaposlenikIme { get; set; }
            public int? ZaposlenikId { get; set; }

        }
        public List<ROW> ROWW { get; set; }
    }
}