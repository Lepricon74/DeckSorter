using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckSorter.Models.BaseModels
{
    public abstract class BaseDeck
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
    }
}
