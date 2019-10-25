using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Data.Models
{
    public class Ocjene
    {

        public int Id { get; set; }
        public int ProizvodId { get; set; }
        public int KupacId { get; set; }
        public int Ocjena { get; set; }
        public int IsJelo { get; set; }

        public virtual Klijent Kupac { get; set; }
    }
}
