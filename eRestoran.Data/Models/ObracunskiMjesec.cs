using System.Collections.Generic;

namespace eRestoran.Data.Models
{
    public class ObracunskiMjesec
    {
        public int Id { get; set; }
        public int Godina { get; set; }
        public int Mjesec { get; set; }
        public virtual ICollection<RadnoVrijeme> RadnoVrijeme { get; set; }
    }
}