using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emailList = new Dictionary<string, string>();

            while (true) {

                string name = Console.ReadLine().Trim();
                if (name == "stop") break;

                string email = Console.ReadLine().Trim();
                string emailEnd = email.Substring(email.Length-3);
                if (emailEnd == ".us" || emailEnd == ".uk") continue;

                emailList[name] = email;
            }

            foreach (KeyValuePair<string,string> entry in emailList) {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
