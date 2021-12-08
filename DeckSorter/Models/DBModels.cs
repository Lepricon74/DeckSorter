using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckSorter.Models.BaseModels;

//Модели базы данных
namespace DeckSorter.Models.DBModels
{
    public class Deck : BaseDeck
    {
        public string Cards { get; set; }
    }
}
