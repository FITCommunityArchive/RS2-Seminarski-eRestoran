using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.Api.VM
{
    public class SkladisteVM
    {
        public int Id { get; set; }
        public String Kvadratura { get; set; }
        public String Lokacija { get; set; }
        public string TipSkladista{ get; set; }
        public int TipId { get; set; }



    }
}