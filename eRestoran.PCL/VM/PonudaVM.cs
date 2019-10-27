
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.VM
{
    public class PonudaVM
    {
        public class PonudaInfo
        {
            public int? Id { get; set; }
            public string Kategorija { get; set; }
            public string Naziv { get; set; }
            public double Cijena { get; set; }
            public int Kolicina { get; set; }
            public string KolicinaString { get; set; }
            public string Ocjena { get; set; }
            public int? ProdataKolicina { get; set; }
            public string imageUrl { get; set; }
            public bool IsJelo { get; set; }
        }
        public List<PonudaInfo> Ponuda { get; set; }
        public List<PonudaInfo> Pica { get; set; }
        public List<PonudaInfo> Jela { get; set; }
       
        
    }

    public class PonudaKonobarVM
    {
        public List<PonudaRow> Jela { get; set; }
        public List<PonudaRow> Pica { get; set; }
        
    }
    public class PonudaRow
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
    }
}