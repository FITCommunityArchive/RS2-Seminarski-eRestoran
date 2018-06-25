using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.VM
{
    public class PrikazKriticnihZaliha
    {
        public class KriticneZalihe
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public int Kolicina { get; set; }
            public string Sifra { get; set; }
            public string Kategorija { get; set; }

        }
        public List<KriticneZalihe> Kriticne { get; set; }
    }
}