using DeckSorter.Models.DBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DeckSorter.Models.ViewModels;
using DeckSorter.Models.BaseModels;
using DeckSorter.DBRepository;
using DeckSorter.DBRepository.Interfaces;
using DeckSorter.DBRepository.Repositories;
using DeckSorter.Functionality;

namespace DeckSorter.Controllers
{
    //[Route("")]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        IDeckRepository deckRepository;

        public HomeController(ILogger<HomeController> logger, DeckSorterContext dbcontext)
        {
            //_logger = logger;
            deckRepository = new SQLDeckRepository(dbcontext);
        }

        //При обращении к корневому адресу перенаправляем на страницу с колодами
        public IActionResult Index()
        {
            return RedirectPermanent("~/decks");
        }

        //Контроллер возвращающий представление со списком всех колод
        [Route("decks")]
        public IActionResult DecksList()
        {
            //Убираем поле Cards т.к. на главной странице оно не используется
            List<DeckShortViewModel> decksView = deckRepository.GetDecksList().Select(deck => new DeckShortViewModel
                                    {
                                        Id = deck.Id,
                                        Size = deck.Size,
                                        Name = deck.Name,
                                    }).ToList();
            //Сортируем по ID
            return View(decksView.OrderBy(x => x.Id).ToList());
        }

        //Контроллер возвращающий представление с отдельной колодой
        [Route("decks/{deckId:int}")]
        public IActionResult DeckDetail(int deckId)
        {
            //Находим колоду в БД
            Deck deck = deckRepository.GetDetailDeck(deckId);
            //Проверяем, что колода была найдена
            if (deck != null)
            {
                //Создаем объект модели-представления DeckViewModel, преобразуем строку порядком карт в массив
                DeckViewModel deckView = new DeckViewModel { Id = deck.Id, Name = deck.Name, Size = deck.Size, Cards = deck.Cards.Split(',') };
                return View(deckView);
            }
            //Если колода не найдена -возвращаем представление с ошибкой
            else return View("DeckDoesNotExist");
        }

        //Контроллер сбрасывающий порядок карт в исходное состояние      
        [HttpPost]
        public IActionResult ReturnToOriginalState(int deckId)
        {
            Deck deck = deckRepository.GetDetailDeck(deckId);
            if (deck != null)
            {
                //Получаем исходную колоду по заданному размеру
                string originalCardsState = DeckGenerator.GetDeckBySize(deck.Size);
                deckRepository.UpdateDeck(deck.Id, originalCardsState);
                //Возвращаем на ту же страницу, чтобы отобразить изменения
                return Redirect("~/decks/" + deck.Id);
            }        
            else return View("DeckDoesNotExist");
        }

        //Контроллер выполняющий простую перетасовку колоды 
        [HttpPost]
        public IActionResult SimpleShuffle(int deckId)
        {
            //Получаем колоду
            Deck deck = deckRepository.GetDetailDeck(deckId);
            if (deck != null)
            {
                //Получаем новый порядок карт
                string newCards = string.Join(",", Shuffle.SimpleShuffle(deck.Cards.Split(",")));
                deckRepository.UpdateDeck(deck.Id, newCards);
                return Redirect("~/decks/" + deck.Id);
            }
            else return View("DeckDoesNotExist");
        }
        //Контроллер выполняющий эмуляцию перетасовки колоды человеком 
        [HttpPost]
        public IActionResult ManualShuffleEmulation(int deckId)
        {
            Deck deck = deckRepository.GetDetailDeck(deckId);
            if (deck != null)
            {
                //Получаем новый порядок карт
                string newCards = string.Join(",", Shuffle.ManualShuffleEmulation(deck.Cards.Split(",")));
                deckRepository.UpdateDeck(deck.Id, newCards);
                return Redirect("~/decks/" + deck.Id);
            }
            else return View("DeckDoesNotExist");
        }

        //Контроллер выполняющий удаление колоды 
        [HttpPost]
        public IActionResult DeckRemove(int deckId)
        {
            deckRepository.RemoveDeck(deckId);
            return Redirect("~/decks");
        }

        //Get версия контроллера создания колоды 
        [Route("decks/create")]
        [HttpGet]
        public IActionResult DeckCreate()
        {
            return View();
        }

        //POST версия контроллера создания колоды
        [Route("decks/create")]
        [HttpPost]
        public IActionResult DeckCreate(DeckCreateViewModel model)
        {         
            //Проверяем переданный объект
            if (ModelState.IsValid)
            {
                Deck newDeck = new Deck {Size = model.Size,Name = model.Name,Cards = DeckGenerator.GetDeckBySize(model.Size) };
                // добавляем пользователя
                var result = deckRepository.CreateDeck(newDeck);
                return Redirect("~/decks");
            }
            //Если есть нарушения - возвращаем обратно
            return View(model);
        }

        

    }
}
