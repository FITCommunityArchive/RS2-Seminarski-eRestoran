using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Data.Models
{
   public class TipSkladista
    {
        public TipSkladista()
        {
            this.Skladiste=new HashSet<Skladiste>();
        }
       [Key]
       public int Id { get; set; }
       public string Naziv { get; set; }
      
        public virtual ICollection<Skladiste> Skladiste { get; set; }
    }
}
