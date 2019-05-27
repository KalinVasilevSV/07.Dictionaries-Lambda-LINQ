using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Hands_of_Cards
{
    //Completed

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> handsCollection = new Dictionary<string, List<string>>();

            while (true) {

                string[] input = Console.ReadLine().Trim().Split(':').Select(x=>x.Trim()).ToArray();
                string name = input[0];
                if (name == "JOKER") break;

                List<string> draw = new List<string>(input[1].Trim().Split(',').Select(x=>x.Trim()).ToList());

                if (!handsCollection.ContainsKey(name)) {
                    handsCollection[name] = draw.Distinct().ToList();
                }
                else {
                    handsCollection[name] = handsCollection[name].Concat(draw).Distinct().ToList();

                    ////This is less efficient than above but also works
                    //foreach (string card in draw) {
                    //    if (handsCollection[name].Contains(card)) continue;
                    //    else handsCollection[name].Add(card);
                    //}
                }
            }

            Dictionary<string, int> scoringTable = new Dictionary<string, int>();

            foreach (KeyValuePair<string, List<string>> hand in handsCollection) {
                scoringTable[hand.Key] = Score(hand.Value);
            }

            // Prints the person's score
            foreach (KeyValuePair<string,int> score in scoringTable) {
                Console.WriteLine($"{score.Key}: {score.Value}");
            }

            //// Prints the hand
            //foreach (KeyValuePair<string, List<string>> hand in handsCollection) {
            //    Console.WriteLine($"{hand.Key}: {String.Join(", ", hand.Value)}");
            //}

        }

        // Scores each hand
        public static int Score(List<string> hand)
        {
            int score=0;

            foreach (string card in hand) {
                string suit = card.Substring(card.Length-1);
                string value = card.Remove(card.Length - 1);

                int cardScore = 0;

                switch (value) {
                    case "2": cardScore = 2; break;
                    case "3": cardScore = 3; break;
                    case "4": cardScore = 4; break;
                    case "5": cardScore = 5; break;
                    case "6": cardScore = 6; break;
                    case "7": cardScore = 7; break;
                    case "8": cardScore = 8; break;
                    case "9": cardScore = 9; break;
                    case "10": cardScore = 10; break;
                    case "J": cardScore = 11;break;
                    case "Q": cardScore = 12; break;
                    case "K": cardScore = 13; break;
                    case "A": cardScore = 14; break;
                }

                switch (suit) {
                    case "S":cardScore *= 4;break;
                    case "H": cardScore *= 3; break;
                    case "D": cardScore *= 2; break;
                  //case "C": cardScore *= 1; break;
                }

                score += cardScore;
            }

            return score;
        }
    }
}
