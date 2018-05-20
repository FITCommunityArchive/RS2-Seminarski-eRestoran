using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Api.VM
{
    public class ProizvodStavka
    {
        public int ProizvodId { get; set; }
        public String Naziv { get; set; }
        public String  Cijena { get; set; }
        public String TipProizvoda { get; set; }

    }
}