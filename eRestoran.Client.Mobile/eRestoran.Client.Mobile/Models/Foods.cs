using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Client.Mobile.Models
{
    public class Food
    {
        public string Ime { get; set; }
        public string Cijena { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
        public int Podiums { get; set; }
        public int GrandPrixEnetered { get; set; }
        public int WorldChampionships { get; set; }
        public string Ocjena { get; set; }
        public int HighestGridPosition { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Bio { get; set; }

        public string CountryFlag
        {
            get
            {
                return $"{Country}.png".Replace(" ", "");
            }
        }

        public string Photo
        {
            get
            {
                return $"teletina.png".Replace(" ", "");
            }
        }
    }
}
