using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Population_Counter_V2
{
    // This solutoin works

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<City>> populationTable = new Dictionary<string, List<City>>();

            while (true) {

                string[] input = Console.ReadLine().Trim().Split('|').ToArray();
                if (input[0] == "report") break;

                string cityName = input[0];
                string countryName = input[1];
                long cityPopulation = long.Parse(input[2]);

                if (!populationTable.ContainsKey(countryName)) {
                    populationTable[countryName] = new List<City>();
                    populationTable[countryName].Add(new City(cityName, cityPopulation));
                    City.numberOfCountries++;
                }
                else {
                    populationTable[countryName].Add(new City(cityName, cityPopulation));
                }
            }

            //Orders the countries in the Dictionary
            populationTable = populationTable
                .OrderByDescending(country => country.Value.Sum(city => city.cityPopulation))
                .ThenBy(country => country.Value.ElementAt(0).countryNum)
                .ToDictionary(keySelector: pair => pair.Key, elementSelector: pair => pair.Value);

            Dictionary<string, List<City>> result = new Dictionary<string, List<City>>();

            // Orders the lists of cities in each KeyValuePair of the Dictionary
            foreach (KeyValuePair<string, List<City>> country in populationTable) {

                result[country.Key] = country.Value
                    .OrderByDescending(city => city.cityPopulation)
                    .ThenBy(city => city.cityNum)
                    .ToList();
            }

            // Prints out the result
            foreach (KeyValuePair<string, List<City>> country in result) {

                Console.WriteLine($"{country.Key} (total population: {country.Value.Sum(city => city.cityPopulation)})");
                foreach (City city in country.Value) {
                    Console.WriteLine($"=>{city.cityName}: {city.cityPopulation}");
                }
            }
        }

        struct City
        {
            public static int numberOfCities = 0;
            public static int numberOfCountries = 0;

            public string cityName;
            public int cityNum;
            public long cityPopulation;
            public int countryNum;

            public City(string cityName,long cityPopulation)
            {
                this.cityName = cityName;
                this.cityPopulation = cityPopulation;
                this.cityNum = City.numberOfCities++;
                this.countryNum = City.numberOfCountries;
            }
        }


    }
}
