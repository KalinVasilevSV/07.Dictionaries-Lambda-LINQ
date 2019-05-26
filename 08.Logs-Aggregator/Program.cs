using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.Logs_Aggregator
{
    // Finished and works in Judge

    class Program
    {
        static void Main(string[] args)
        {
            int sessionCount = int.Parse(Console.ReadLine());

            Dictionary<string,UserLog> userLogs = new Dictionary<string, UserLog>();

            for (int i = 0; i< sessionCount; i++) {

                string[] input = Console.ReadLine().Trim().Split().ToArray();

                if (!userLogs.ContainsKey(input[1])) {
                    userLogs[input[1]] = new UserLog(input[1]);
                    userLogs[input[1]].ipList.Add(input[0]);
                    userLogs[input[1]].loggedTime += int.Parse(input[2]);
                }
                else {
                    userLogs[input[1]].ipList.Add(input[0]);
                    userLogs[input[1]].loggedTime += int.Parse(input[2]);
                }
            }

            // Creates the results dictionary
            Dictionary<string, UserLog> resultingLog = new Dictionary<string, UserLog>();

            // Orders the dictionary user names
            foreach(KeyValuePair<string,UserLog> userLog in userLogs) {
                resultingLog = userLogs.OrderBy(user => user.Key).ToDictionary(user => user.Key, user => user.Value);
            }

            // Orders the user IPs
            foreach(KeyValuePair<string,UserLog> userLog in resultingLog) {
                userLog.Value.ipList = userLog.Value.ipList.Distinct().OrderBy(ip => ip).ToList();
            }

            // Prints the result
            foreach(KeyValuePair<string,UserLog> userLog in resultingLog) {
                Console.WriteLine($"{userLog.Key}: {userLog.Value.loggedTime} [{String.Join(", ",userLog.Value.ipList)}]");
            }

        }


        class UserLog
        {
            public string userName;
            public int loggedTime = 0;
            public List<string> ipList = new List<string>();

            public UserLog(string userName)
            {
                this.userName = userName;
            }
        }
    }
}
