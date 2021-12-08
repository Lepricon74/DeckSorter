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

		//Т.к. контекст был зарегистривован в качестве сервиса - можем его передавать в констукторы классов: 
		public SQLDeckRepository(DeckSorterContext _db)
		{
			db = _db;
		}

		//Создание новой колоды
		public int CreateDeck(Deck newDeck)
        {
			db.Decks.Add(newDeck);
			Save();
			return 0;
		}
		//Удаление колоды
		public int RemoveDeck(int deckId)
		{
			Deck deckToRemove = db.Decks
					.Where(deck => deck.Id == deckId)
					.FirstOrDefault();
			//Проверяем, что колода с перданным Id была найдена
			if (deckToRemove == null) return 1;
			db.Decks.Remove(deckToRemove);
			Save();
			return 0;
		}
		//Получение всех колод
		public List<Deck> GetDecksList()
		{
			//выбираем колоды из таблицы Decks
			return db.Decks.ToList();
		}

		//Одновление порядка карт в колоде
		public int UpdateDeck(int deckId, string newCards)
		{
			Deck deckForUpdate = db.Decks.FirstOrDefault(deck => deck.Id == deckId);
			//Проверяем, что колода с перданным Id была найдена
			if (deckForUpdate == null) return 1;
			//Установливаем новый порядок карт
			deckForUpdate.Cards = newCards;
			db.Decks.Update(deckForUpdate);
			Save();
			return 0;
		}
		//Полученое отдельной колоды
		public Deck GetDetailDeck(int deckId)
		{
			Deck resultDeck = db.Decks.FirstOrDefault(deck => deck.Id == deckId);			
			return resultDeck;
		}

		//Метод сохранения изменений
		private void Save()
        {
            db.SaveChanges();
        }  
    }
}
