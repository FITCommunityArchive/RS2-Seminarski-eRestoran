using eRestoran.Data.Models;

namespace eRestoran.PCL.VM
{
    public class VerifikovanKorisnikVM
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
    }
}