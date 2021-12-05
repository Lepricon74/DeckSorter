using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckSorter.Models.DBModels;
using DeckSorter.Models.ViewModels;
using DeckSorter.Models.BaseModels;

namespace DeckSorter.DBRepository.Interfaces
{
    public interface IDeckRepository 
    {
        int CreateDeck(Deck newDeck);
        int RemoveDeck(int deckId);
        List<Deck> GetDecksList();
        int UpdateDeck(int deckId, string newCards);
        Deck GetDetailDeck(int deckId);
        int GetNewDeckId();
    }
}
