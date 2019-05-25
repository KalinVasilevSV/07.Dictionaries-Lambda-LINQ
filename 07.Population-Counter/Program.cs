using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Country> populationTable = new Dictionary<string, Country>();

            while (true) {

                string[] input = Console.ReadLine().Split('|');
                if (input[0] == "report") break;

                string countryName = input[1];
                string cityName = input[0];
                int cityPopulation = int.Parse(input[2]);

                if (!populationTable.Keys.Contains(countryName)) {
                    populationTable[countryName] = new Country(countryName, cityName, cityPopulation);
                }
                else if(populationTable[countryName].cities.Contains(cit)){

                }

            }


        }

        class Country
        {
            static int numberOfCountries = 0;

            public int entryNum;
            public string countryName;
            public List<City> cities = new List<City>();

            public Country(string countryName,string cityName,int cityPopulation)
            {
                this.countryName = countryName;
                cities.Add(new City(cityName, cityPopulation));

                numberOfCountries++;
                this.entryNum = numberOfCountries;
            }

            int Population
            {
                get { int population=0;
                    foreach (City city in cities) {
                        population += city.cityPopulation;
                    }
                    return population;
                }
            }

            class City
            {
                static int numberOfCities = 0;

                public int entryNum;
                public string cityName;
                public int cityPopulation;

                public City(string cityName,int cityPopulation)
                {
                    this.cityName = cityName;
                    this.cityPopulation = cityPopulation;

                    numberOfCities++;
                    this.entryNum = numberOfCities;
                }
            }
        }
    }
}
