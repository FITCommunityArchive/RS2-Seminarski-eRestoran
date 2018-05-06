using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRestoran.VM
{
    public class PonudaUrediVM
    {
        [Required]
        public string Naziv { get; set; }
        [Required]
        public int ID { get; set; }
        [Required]
        public string Kategorija { get; set; }
        [Required]
        public double Cijena { get; set; }
        [Required]
        public int  Kolicina { get; set; }
        public List<SelectListItem> KategorijeLista { get; set; }

    }
}