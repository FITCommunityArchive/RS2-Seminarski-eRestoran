using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.PCL.VM
{
    public class RacunVM
    {
        public class RacunRow
        {
            public DateTime DatumIzdavanja { get; set; }
            public double Iznos { get; set; }
            public int BrojNarudzbi { get; set; }
            public int Dan { get; set; }


        }
        public List<RacunRow> Zarade { get; set; }
        public RacunRow DanasnjaZarada { get; set; }

        public int dan { get; set; }
        public int mjesec { get; set; }
        public int godina { get; set; }
        public DateTime? date { get; set; }

    }
}