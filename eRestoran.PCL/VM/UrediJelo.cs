using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.PCL.VM
{
    public class UrediJelo
    {
        public int JeloId { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string  Menu { get; set; }
        public List<ProizvodStavka> ListaStavki { get; set; }
        public string Sifra { get; set; }
        public string SlikaUrl { get; set; }
    }
}