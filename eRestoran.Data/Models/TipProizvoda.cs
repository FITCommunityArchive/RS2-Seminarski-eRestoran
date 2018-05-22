using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Data.Models
{
    public enum MjernaJedinica
    {
        Kilogram=1,Dekagram,Gram,Litar,Decilitar,Centilitar
    }


    public class TipProizvoda
    {
        public TipProizvoda()
        {
            this.Proizvod=new HashSet<Proizvod>();
        }
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public MjernaJedinica MjernaJedinica { get; set; }

        public virtual ICollection<Proizvod> Proizvod { get; set; }
    }
}