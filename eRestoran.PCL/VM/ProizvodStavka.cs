using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.PCL.VM
{
    public class ProizvodStavka
    {
        public int ProizvodId { get; set; }
        public string Naziv { get; set; }
        public string  Cijena { get; set; }
        public string TipProizvoda { get; set; }
        public string Kolicina { get; set; }
    }
}