using System.Collections.Generic;

namespace eRestoran.PCL.VM
{
    public class NaloziVM
    {
        public List<NalogsRow> Nalozi { get; set; }
        public class NalogsRow
        {
            public string ImePrezime { get; set; }
            public string Telefon { get; set; }
            public string Username { get; set; }
            public string Zaposlenik { get; set; }
            public int Id { get; set; }
        }
    }
}