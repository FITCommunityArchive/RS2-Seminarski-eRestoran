using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.PCL.VM
{
    public class StoloviRezervacijaVM
    {
        public int StoId { get; set; }
        public int? RezervacijaId { get; set; }
        public DateTime? DatumOd { get; set; }
        public int RedniBrojStola { get; set; }
        public bool IsSlobodan { get; set; }
    }
}