using System;
using System.Collections.Generic;

namespace _03.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourceInventory = new Dictionary<string, int>();

            while (true) {
                string resource = Console.ReadLine();
                if (resource == "stop") break;

                int quantity = int.Parse(Console.ReadLine());

                if (!resourceInventory.ContainsKey(resource))
                    resourceInventory[resource] = quantity;
                else
                    resourceInventory[resource] += quantity;
            }

            foreach(KeyValuePair<string,int> entry in resourceInventory) {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
