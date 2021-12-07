using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckSorter.Models.DBModels;


namespace DeckSorter.Functionality
{
    public static class Shuffle
    {
        public static string[] SimpleShuffle(string[] cards)
        {
            var rand = new Random();
            for (int i = 0; i < cards.Length-1; i++)
            {
                int j = rand.Next(i + 1,cards.Length-1);
                // обменять значения cards[j] и cards[i]
                var temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
            return cards;
        }

        public static string[] ManualShuffleEmulation(string[] cards)
        {
            string[] result = new string[cards.Length];
            int prevEnd = cards.Length;
            int resultIndex = 0;
            for (int pow = 0; GetCurStartIndrex(prevEnd, pow) >= 0; pow++)
            {
                int curStart = GetCurStartIndrex(prevEnd, pow);
                if (GetCurStartIndrex(curStart, pow) < 0) break;
                for (int j = curStart; j < prevEnd; j++)
                {
                    result[resultIndex] = cards[j];
                    resultIndex++;
                }
                prevEnd = curStart;
            }
            for (int i = 0; i < prevEnd; i++)
            {
                result[resultIndex] = cards[i];
                resultIndex++;
            }
            return result;

            int GetCurStartIndrex(int prevEndIndex, int pow)
            {
                return cards.Length - ((cards.Length - prevEndIndex) + (int)Math.Pow(2, pow));
            }
        }
    }
}
