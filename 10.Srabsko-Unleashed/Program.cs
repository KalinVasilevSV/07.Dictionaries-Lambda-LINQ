using System;
using System.Linq;
using System.Collections.Generic;

namespace _10.Srabsko_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,long>> singerProfitsByVenue = new Dictionary<string, Dictionary<string,long>>();

            while (true) {

                string input = Console.ReadLine();
                if (input == "End") break;

                string singerName = input.Substring(0, input.IndexOf('@'));
                if (!singerName.EndsWith(" ")) continue; //Judge fails at compile time if EndsWith is give type char but works fine on my machine
                else singerName = singerName.Trim();

                string[] concert = input.Substring(input.IndexOf('@')+1).Split();
                long ticketsCount;
                long ticketsPrice;
                try {
                    ticketsCount = long.Parse(concert[concert.Length - 2]);
                    ticketsPrice = long.Parse(concert[concert.Length - 1]);
                }
                catch (Exception) {
                    //NO longer needed to access the message of the exception
                    //Possible exception in this task were IndexOutOfRangeException and FormatException
                    //Console.WriteLine(e.Message);
                    continue;
                }

                string venueName = String.Join(" ",concert.Take(concert.Length - 2));

                if (!singerProfitsByVenue.ContainsKey(venueName)) {
                    singerProfitsByVenue[venueName] = new Dictionary<string, long>();
                }

                if (!singerProfitsByVenue[venueName].ContainsKey(singerName)) {
                    singerProfitsByVenue[venueName][singerName] = (ticketsCount * ticketsPrice);
                }
                else {
                    singerProfitsByVenue[venueName][singerName] += (ticketsCount * ticketsPrice);
                }
            }

            Dictionary<string, Dictionary<string, long>> results = new Dictionary<string, Dictionary<string, long>>();

            foreach (KeyValuePair<string,Dictionary<string,long>> venue in singerProfitsByVenue) {
                results[venue.Key] = venue.Value.OrderByDescending(singer => singer.Value).ToDictionary(keySelector:singer=>singer.Key,elementSelector:singer=>singer.Value);
            }

            foreach (KeyValuePair<string,Dictionary<string,long>> venue in results) {
                Console.WriteLine($"{venue.Key}");
                foreach(KeyValuePair<string,long> singer in venue.Value) {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }

    }
}
