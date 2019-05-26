using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Population_Counter
{
    // Completed and works. V2 might be more optimal

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
                long cityPopulation = long.Parse(input[2]);

                if (!populationTable.ContainsKey(countryName)) {
                    populationTable[countryName] = new Country(countryName);
                    populationTable[countryName].cities.Add(new Country.City(cityName, cityPopulation));
                }
                else {
                    populationTable[countryName].cities.Add(new Country.City(cityName, cityPopulation));
                }
            }

            // Orders the countries in the Dictionary 
            populationTable=populationTable.OrderByDescending(x => x.Value.cities.Sum(y => y.cityPopulation)).ThenBy(x => x.Value.countryNum).ToDictionary(x=>x.Key,elementSelector:y=>y.Value);
           
            // Orders the Cities in every country in a descending order by population, keeps those with the same population in order of entry
            foreach (KeyValuePair<string, Country> country in populationTable) {
                country.Value.cities=country.Value.cities.OrderByDescending(x => x.cityPopulation).ThenBy(x=>x.cityNum).ToList();
            }

            // Prints the results
            foreach (KeyValuePair<string, Country> country in populationTable) {

                Console.WriteLine($"{country.Key} (total population: {country.Value.cities.Sum(x=>x.cityPopulation)})");
                foreach (Country.City city in country.Value.cities) {
                    Console.WriteLine($"=>{city.cityName}: {city.cityPopulation}");
                }
            }

        }

        class Country
        {
            public static int numberOfCountries = 0;
            public int countryNum;
            public string countryName;
            public List<City> cities = new List<City>();

            public Country(string countryName)
            {
                this.countryName = countryName;
                this.countryNum = numberOfCountries++;
            }

            public struct City
            {
                public static int numberOfCities = 0;

                public int cityNum;
                public string cityName;
                public long cityPopulation;

                public City(string cityName, long cityPopulation)
                {
                    this.cityName = cityName;
                    this.cityPopulation = cityPopulation;

                    this.cityNum = numberOfCities++;
                }
            }

        }
    }
}
