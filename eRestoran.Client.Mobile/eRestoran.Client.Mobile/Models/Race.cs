using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Client.Mobile.Models
{
    public class Race
    {
        public string Name { get; set; }
        public string Circuit { get; set; }
        public int NumberOfLaps { get; set; }
        public double CircuitLength { get; set; }
        public double RaceDistance { get; set; }
        public DateTime Date { get; set; }
        public string MapUrl { get; set; }

        public bool IsLast { get; set; }

    }
}
