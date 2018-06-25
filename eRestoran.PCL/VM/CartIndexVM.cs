using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.PCL.VM
{
    public class CartIndexVM
    {

        public List<CartRow> Jela { get; set; }
        public List<CartRow> Pica { get; set; }
        public double TotalPrice { get; set; }

    }
    public class CartRow
    {
        public int? Id { get; set; }
        public string Naziv { get; set; }
        public double  Cijena { get; set; }
        public double TotalRowPrice { get; set; }
        public string Imageurl { get; set; }
        public string Kategorija { get; set; }
        public int StanjeKolicina { get; set; }
        public int Kolicina { get; set; }
    }
}