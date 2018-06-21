using eRestoran.Data.Models;

namespace eRestoran.Api.VM
{
    public class VerifikovanKorisnikVM
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
    }
}