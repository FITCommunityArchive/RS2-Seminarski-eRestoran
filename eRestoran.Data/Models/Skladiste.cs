using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Data.Models
{
    public class Skladiste
    {
        public Skladiste()
        {
            this.Proizvod=new HashSet<Proizvod>();
        }
        [Key]
        public int Id { get; set; }
        public string Adresa { get; set; }
        public string Kvadratura { get; set; }
        public int TipId { get; set; }

        public virtual TipSkladista Tip { get; set; }
        public virtual ICollection<Proizvod> Proizvod { get; set; }

    }

    
}