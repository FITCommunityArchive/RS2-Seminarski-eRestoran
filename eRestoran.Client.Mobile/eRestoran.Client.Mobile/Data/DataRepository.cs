using eRestoran.Client.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace eRestoran.Client.Mobile.Data
{
    public static class DataRepository
    {
        public static IList<Food> Drivers { get; }
        public static IList<Race> Races
        {
            get;
        }
        public static Food MockDriver
        {
            get
            {
                return Drivers[0];
            }
        }

        public static Race MockRace
        {
            get
            {
                return Races[0];
            }
        }

        static DataRepository()
        {
            Drivers = new ObservableCollection<Food>
            {
                new Food
                {
                    Ime = "Teletina ispod sača",
                    Team = "Hrana",
                    Country = "",
                    Cijena = "20.50",
                    Podiums = 0,
                    GrandPrixEnetered = 0,
                    WorldChampionships = 4,
                    Ocjena = "4.5 ",
                    HighestGridPosition = 1,
                    DateOfBirth = new DateTime(1987,7,3),
                    PlaceOfBirth = "Heppenheim, Germany",
                    Bio="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                }
            };

            Races = new ObservableCollection<Race>()
            {
                new Race
                {
                    Name="Australian Grand Prix",
                    Circuit="Melbourne",
                    CircuitLength=5.303,
                    RaceDistance=307.574,
                    NumberOfLaps=58,
                    Date = new DateTime(2017, 03, 26),
                    MapUrl = @"https://www.formula1.com/content/fom-website/en/championship/races/2017/Australia/_jcr_content/circuitMap.img.png/1458295855148.png"
                },
                new Race
                {
                    Name="Chinese Grand Prix",
                    Circuit="Shanghai International Circuit",
                    CircuitLength=5.451,
                    RaceDistance=305.066,
                    NumberOfLaps=56,
                    Date = new DateTime(2017, 04, 09)
                },
                new Race
                {
                    Name="Bahrain Grand Prix",
                    Circuit="Bahrain International Circuit",
                    CircuitLength=5.451,
                    RaceDistance=305.066,
                    NumberOfLaps=56,
                    Date = new DateTime(2017, 04, 16)
                },
                new Race
                {
                    Name="Russian Grand Prix",
                    Circuit="Sochi Autodrom",
                    CircuitLength=5.848,
                    RaceDistance=305.066,
                    NumberOfLaps=53,
                    Date = new DateTime(2017, 04, 30)
                },
                new Race
                {
                    Name="Premio De Espana",
                    Circuit="Circuit De Barcelona-Catalunya",
                    CircuitLength=4.655,
                    RaceDistance=307.104,
                    NumberOfLaps=66,
                    Date = new DateTime(2017, 05, 14)
                },
                new Race
                {
                    Name="Grand Prix De Monaco",
                    Circuit="Circuit De Monaco",
                    CircuitLength=3.337,
                    RaceDistance=260.286,
                    NumberOfLaps=78,
                    Date = new DateTime(2017, 05, 28)
                },
                new Race
                {
                    Name="Grand Prix Du Canada",
                    Circuit="Circuit Gilles-Villeneuve",
                    CircuitLength=361,
                    RaceDistance=305.27,
                    NumberOfLaps=70,
                    Date = new DateTime(2017, 06, 11),
                    IsLast=true
                },

            };
        }
    }
}
