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
            List<DeckShortViewModel> decks = deckRepository.GetDecksList();
            return View(decks);
        }

        [Route("decks/{deckId:int}")]
        public IActionResult DeckDetail(int deckId)
        {
            DeckViewModel deck = deckRepository.GetDetailDeck(deckId);
            return View(deck);
        }

        [Route("decks/create")]
        [HttpGet]
        public IActionResult DeckCreate()
        {
            return View();
        }

        [Route("decks/create")]
        [HttpPost]
        public IActionResult DeckCreate(BaseDeck model)
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
