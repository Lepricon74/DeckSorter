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

        public IActionResult Index()
        {
            return RedirectPermanent("~/decks");
        }

        [Route("decks")]
        public IActionResult DecksList()
        {
            List<DeckShortViewModel> decksView = deckRepository.GetDecksList().Select(deck => new DeckShortViewModel
                                    {
                                        Id = deck.Id,
                                        Size = deck.Size,
                                        Name = deck.Name,
                                    }).ToList();
            return View(decksView);
        }

        [Route("decks/{deckId:int}")]
        public IActionResult DeckDetail(int deckId)
        {
            Deck deck = deckRepository.GetDetailDeck(deckId);
            DeckViewModel deckView = new DeckViewModel { Id = deck.Id, Name = deck.Name, Size = deck.Size, Cards = deck.Cards.Split(',') };
            return View(deckView);
        }

        //[Route("decks/{deckId:int}/simpleshuffle")]
        [HttpPost]
        public IActionResult SimpleShuffle(int deckId)
        {
            Deck deck = deckRepository.GetDetailDeck(deckId);
            string newCards =string.Join(",", Shuffle.SimpleDeckShuffle(deck.Cards.Split(",")));
            deckRepository.UpdateDeck(deck.Id,newCards);
            return Redirect("~/decks/"+deck.Id);
        }

        [Route("decks/create")]
        [HttpGet]
        public IActionResult DeckCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeckCreate(DeckCreateViewModel model)
        {
            const string STANDARTDECK52 = "101,102,103,104,105,106,107,108,109,110,111,112,113," +
                                          "201,202,203,204,205,206,207,208,209,210,211,212,213," +
                                          "301,302,303,304,305,306,307,308,309,310,311,312,313," +
                                          "401,402,403,404,405,406,407,408,409,410,411,412,413";

            if (ModelState.IsValid)
            {
                int newDeckId = deckRepository.GetNewDeckId();
                Deck newDeck = new Deck { Id = newDeckId, Size = model.Size,Name = model.Name,Cards = STANDARTDECK52 };
                // добавляем пользователя
                var result = deckRepository.CreateDeck(newDeck);
                return Redirect("~/decks");
            }
            return View(model);
        }

    }
}
