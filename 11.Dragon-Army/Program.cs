using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, DragonStats>> dragonsRoster = new Dictionary<string, SortedDictionary<string, DragonStats>>();
            int numDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numDragons; i++) {

                string[] input = Console.ReadLine().Trim().Split();
                string dragonType = input[0];
                string dragonName = input[1];
                string damage = input[2];
                string health = input[3];
                string armor = input[4];

                if (!dragonsRoster.ContainsKey(dragonType)) {
                    dragonsRoster[dragonType] = new SortedDictionary<string, DragonStats>();
                }

                dragonsRoster[dragonType][dragonName] = new DragonStats(damage, health, armor);
            }

            foreach(KeyValuePair<string,SortedDictionary<string,DragonStats>> dragonType in dragonsRoster) {
                Console.WriteLine("{0}::({1:0.00}/{2:0.00}/{3:0.00})",
                    dragonType.Key, dragonType.Value.Average(dragon => (float)dragon.Value.damage), dragonType.Value.Average(dragon => (float)dragon.Value.health),dragonType.Value.Average(dragon => (float)dragon.Value.armor));

                foreach (KeyValuePair<string,DragonStats> dragon in dragonType.Value) {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.damage}, health: {dragon.Value.health}, armor: {dragon.Value.armor}");
                }
            }
        }


        class DragonStats
        {
            public int damage = 45;
            public int health = 250;
            public int armor = 10;

            public DragonStats(string damage, string health, string armor)
            {
                if (damage != "null") this.damage = int.Parse(damage);
                if (health != "null") this.health = int.Parse(health);
                if (armor != "null") this.armor = int.Parse(armor);
            }
        }
    }
}
