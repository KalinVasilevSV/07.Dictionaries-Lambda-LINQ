using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> userLogs = new SortedDictionary<string, Dictionary<string, int>>();

            while (true) {

                string[] input = Console.ReadLine().Trim().Split();
                if (input[0] == "end") break;
                input=input.Select(x => x.Substring(x.IndexOf('=')+1)).ToArray();

                string ip = input[0];
                string name = input[2];

                if (!userLogs.ContainsKey(name)) {
                    userLogs[name] = new Dictionary<string, int>();
                    userLogs[name][ip] = 1;
                }
                else {

                    if (!userLogs[name].ContainsKey(ip)) {
                        userLogs[name][ip] = 1;
                    }
                    else {
                        userLogs[name][ip]++;
                    }
                }
            }

            // Print userLogs contants
            foreach (KeyValuePair<string, Dictionary<string, int>> userName in userLogs) {

                // Creates a List of strings representing the IPs and number of visits for each IP
                List<string> ips = userName.Value.Select(ipentry => ($"{ipentry.Key} => {ipentry.Value}")).ToList();

                Console.WriteLine($"{userName.Key}:");
                Console.WriteLine(String.Join(", ", ips)+".");
            }
        }

        ////This method could be used instead of the anonymous function at line 17
        ////It is currently unused
        //public static string ExtractInfo(string input)
        //{
        //    return input.Substring(input.IndexOf('='));
        //}

    }
}
