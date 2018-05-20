using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class KlijentNaruciVM
    {
        

            public int KlijentId { get; set; }
            public string ImePrezime { get; set; }
            public int BrojNarudzbi { get; set; }
            public double PotrosioPara { get; set; }
            public List<Narudzba> Narudzba { get; set; }
            
       
    }
}