using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.Legendary_Farming
{
    //Completed

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> inventory = new Dictionary<string, int>();
            inventory["shards"] = 0;
            inventory["fragments"] = 0;
            inventory["motes"] = 0;
            while (true) {
                string[] input = Console.ReadLine().Trim().ToLower().Split().ToArray();

                for (int i = 1; i < input.Length; i+=2) {

                    if (!inventory.ContainsKey(input[i])) {
                        inventory[input[i]] = 0;
                    }
                    inventory[input[i]] += int.Parse(input[i - 1]);

                    if (inventory["shards"] >= 250) {
                        inventory["shards"] -= 250;
                        Console.WriteLine("Shadowmourne obtained!"); goto LegendaryObtained;
                    }
                    else if (inventory["fragments"] >= 250) {
                        inventory["fragments"] -= 250;
                        Console.WriteLine("Valanyr obtained!"); goto LegendaryObtained;
                    }
                    else if (inventory["motes"] >= 250) {
                        inventory["motes"] -= 250;
                        Console.WriteLine("Dragonwrath obtained!"); goto LegendaryObtained;
                    }
                }

                
            }
            LegendaryObtained:;
            
            // Following Dicionaries are the inventory split in two
            //inventory.Where() requires ToDictionary as well. The Dictionary constructor reqires a parameter of type Dictionary
            Dictionary<string, int> legendaryMaterials = new Dictionary<string, int>(inventory.Where(item => item.Key == "shards" || item.Key == "fragments" || item.Key == "motes").ToDictionary(keySelector: item => item.Key, elementSelector: item => item.Value));
            legendaryMaterials = legendaryMaterials.OrderByDescending(item => item.Value).ThenBy(item=>item.Key).ToDictionary(keySelector:item=>item.Key,elementSelector:item=>item.Value);

            // Could use SortedDictionary for remainingMaterials but that would preclude any other sorting options
            Dictionary<string,int> remainingMaterials =new Dictionary<string, int>(inventory.Where(item => item.Key != "shards" && item.Key != "fragments" && item.Key != "motes").ToDictionary(keySelector: item => item.Key, elementSelector: item => item.Value));
            remainingMaterials = remainingMaterials.OrderBy(item => item.Key).ToDictionary(keySelector:item => item.Key, elementSelector:item =>item.Value);

            // Prints the result
            foreach(KeyValuePair<string,int> item in legendaryMaterials) {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (KeyValuePair<string, int> item in remainingMaterials) {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
