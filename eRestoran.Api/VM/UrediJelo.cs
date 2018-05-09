using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Api.VM
{
    public class UrediJelo
    {
        public int JeloId { get; set; }
        public String Naziv { get; set; }
        public double Cijena { get; set; }
        public String  Menu { get; set; }
        public List<ProizvodStavka> ListaStavki { get; set; }

    }
}