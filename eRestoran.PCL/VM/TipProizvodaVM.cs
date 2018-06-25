using eRestoran.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRestoran.PCL.VM
{
    public class TipProizvodaVM
    {
        public int Id { get; set; }
        public String Naziv { get; set; }
        public MjernaJedinica mjernaJedinica { get; set; }

    }
}