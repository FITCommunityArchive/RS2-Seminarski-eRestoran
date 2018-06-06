using System;

namespace eRestoran.Data.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        
        public DateTime datumVrijemeOd { get; set; }
        public DateTime datumVrijemeDo { get; set; }
        public int KlijentId { get; set; }
        public int StoId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Sto Sto { get; set; }
        public virtual Klijent Klijent { get; set; }
    }
}