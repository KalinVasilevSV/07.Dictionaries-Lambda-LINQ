using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Phonebook_Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, string> Phonebook = new SortedDictionary<string, string>();

            while (true) {

                Action action = new Action(Console.ReadLine());

                action.PerfomOn(Phonebook);

                if (action.action == "END")
                    break;
            }
        }

        class Action
        {
            public string action;
            string name;
            string tel;

            public Action(string input)
            {
                string[] instructions = input.Trim().Split();

                this.action = instructions[0];

                try {
                    this.name = instructions[1];
                }
                catch (IndexOutOfRangeException) { }

                try {
                    this.tel = instructions[2];
                }
                catch (IndexOutOfRangeException) { }
            }

            public void PerfomOn(SortedDictionary<string, string> phonebook)
            {
                switch (this.action) {

                    case "A":
                        phonebook[this.name] = this.tel;
                        break;
                    case "S":
                        if (phonebook.ContainsKey(this.name)) {
                            Console.WriteLine($"{phonebook.Keys.Single(name => name == this.name)} -> {phonebook[this.name]}");
                        }
                        else {
                            Console.WriteLine($"Contact {this.name} does not exist.");
                        }
                        break;
                    case "ListAll":
                        foreach(KeyValuePair<string,string> entry in phonebook) {
                            Console.WriteLine($"{entry.Key} -> {entry.Value}");
                        }
                        break;

                    default: break;
                }
            }
        }


    }
}
