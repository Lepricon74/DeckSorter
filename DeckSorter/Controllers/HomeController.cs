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
            return View(decksView.OrderBy(x => x.Id).ToList());
        }

        [Route("decks/{deckId:int}")]
        public IActionResult DeckDetail(int deckId)
        {
            Deck deck = deckRepository.GetDetailDeck(deckId);
            DeckViewModel deckView = new DeckViewModel { Id = deck.Id, Name = deck.Name, Size = deck.Size, Cards = deck.Cards.Split(',') };
            return View(deckView);
        }

        [HttpPost]
        public IActionResult ReturnToOriginalState(int deckId)
        {
            Deck deck = deckRepository.GetDetailDeck(deckId);
            if (deck != null)
            {
                string originalCardsState = DeckGenerator.GetDeckBySize(deck.Size);
                deckRepository.UpdateDeck(deck.Id, originalCardsState);
            }
            return Redirect("~/decks/" + deck.Id);
        }

        //[Route("decks/{deckId:int}/simpleshuffle")]
        [HttpPost]
        public IActionResult SimpleShuffle(int deckId)
        {
            Deck deck = deckRepository.GetDetailDeck(deckId);
            string newCards =string.Join(",", Shuffle.SimpleShuffle(deck.Cards.Split(",")));
            deckRepository.UpdateDeck(deck.Id,newCards);
            return Redirect("~/decks/"+deck.Id);
        }

        [HttpPost]
        public IActionResult ManualShuffleEmulation(int deckId)
        {
            Deck deck = deckRepository.GetDetailDeck(deckId);
            string newCards = string.Join(",", Shuffle.ManualShuffleEmulation(deck.Cards.Split(",")));
            deckRepository.UpdateDeck(deck.Id, newCards);
            return Redirect("~/decks/" + deck.Id);
        }

        [HttpPost]
        public IActionResult DeckRemove(int deckId)
        {
            deckRepository.RemoveDeck(deckId);
            return Redirect("~/decks");
        }

        [Route("decks/create")]
        [HttpGet]
        public IActionResult DeckCreate()
        {
            return View();
        }

        [Route("decks/create")]
        [HttpPost]
        public IActionResult DeckCreate(DeckCreateViewModel model)
        {         
            if (ModelState.IsValid)
            {
                Deck newDeck = new Deck {Size = model.Size,Name = model.Name,Cards = DeckGenerator.GetDeckBySize(model.Size) };
                // добавляем пользователя
                var result = deckRepository.CreateDeck(newDeck);
                return Redirect("~/decks");
            }
            return View(model);
        }

        

    }
}
