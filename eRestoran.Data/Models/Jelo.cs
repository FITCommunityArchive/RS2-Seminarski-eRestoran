using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Data.Models
{
    public class Jelo
    {
        public Jelo()
        {
            this.HistorijaCijenaJela = new HashSet<HistorijaCijenaJela>();
            this.JelaStavke = new HashSet<JelaStavke>();
            this.NarudzbaStavke = new HashSet<NarudzbaStavke>();

        }
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        [Required]
        public string Sifra { get; set; }
        public string Menu { get; set; }

        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
        public virtual ICollection<HistorijaCijenaJela> HistorijaCijenaJela { get; set; }
        public virtual ICollection<JelaStavke> JelaStavke { get; set; }


    }
}