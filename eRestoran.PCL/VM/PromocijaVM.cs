using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.PCL.VM
{
   public class PromocijaVM
    {
        public DateTime DatumOd { get; set; }

        public DateTime DatumDo { get; set; }

        public double StaraCijena { get; set; }

        public double PromotivnaCijena { get; set; }

        public int? JeloId { get; set; }
        public int? ProizvodId { get; set; }

    }
}
