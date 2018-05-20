using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eRestoran.Areas.ModulAdministracija.Models
{


  
        public class DodajJelo
        {
            public int? JeloId { get; set; }
            public int? ProizvodId { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
            public int Kolicina { get; set; }
            public List<SelectListItem> Proizvodi { get; set; }
            public string menu { get; set; }
            public double? Cijena { get; set; }
            public string Sifra { get; set; }
            public string Naziv { get; set; }


        }
      
}