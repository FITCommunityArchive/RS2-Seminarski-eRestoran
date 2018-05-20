
using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Areas.ModulAdministracija.Models
{
    public class JeloJelaStavkeUredi
    {
        public int jeloId { get; set; }
        public string NazivJela { get; set; }
        public double CijenaJela { get; set; }
        public int KolicinaProizvoda { get; set; }
        public string SifraJela { get; set; }
        public string MenuJela { get; set; }
        public int ProizvodId { get; set; }
       public List<JelaStavke> jelastavke { get; set; }
    }
}