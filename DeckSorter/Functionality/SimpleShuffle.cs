using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckSorter.Models.DBModels;



namespace DeckSorter.Functionality
{
    public static class Shuffle
    {
        public static string[] SimpleDeckShuffle(string[] cards)
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
    }
}
