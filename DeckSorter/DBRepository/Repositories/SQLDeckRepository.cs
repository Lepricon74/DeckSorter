using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckSorter.Models.DBModels;
using DeckSorter.DBRepository.Interfaces;
using DeckSorter.Models.BaseModels;
using DeckSorter.Models.ViewModels;

namespace DeckSorter.DBRepository.Repositories
{
    public class SQLDeckRepository : IDeckRepository
    {
		private DeckSorterContext db;
		public SQLDeckRepository(DeckSorterContext _db)
		{
			db = _db;
		}

		public int CreateDeck(Deck newDeck)
        {
			db.Decks.Add(newDeck);
			Save();
			return 1;
		}
		public int RemoveDeck(int deckId)
		{
			Deck deckToRemove = db.Decks
					.Where(deck => deck.Id == deckId)
					.FirstOrDefault();
			if (deckToRemove == null) return 0;
			db.Decks.Remove(deckToRemove);
			Save();
			return 1;
		}
		public List<Deck> GetDecksList()
		{
			//выбираем колоды из таблицы Decks
			return db.Decks.ToList();
		}
		public int UpdateDeck(int deckId, string newCards)
		{
			Deck deckForUpdate = db.Decks.FirstOrDefault(deck => deck.Id == deckId);
			if (deckForUpdate == null)
			{
				//return "There is no such parking";
				return -1;
			}
			deckForUpdate.Cards = newCards;
			db.Decks.Update(deckForUpdate);
			Save();
			return 1;
		}
		public Deck GetDetailDeck(int deckId)
		{
			Deck resultDeck = db.Decks.FirstOrDefault(deck => deck.Id == deckId);			
			return resultDeck;
		}

		public int GetNewDeckId()
		{
			var decksList = db.Decks.Select(deck => new DeckShortViewModel
			{
										Id = deck.Id,
										Name = deck.Name,
										Size = deck.Size,
									}).ToList();
			return (decksList.Count() == 0) ? 1 : decksList.Last().Id + 1;
		}
		private void Save()
        {
            db.SaveChanges();
        }  
    }
}
