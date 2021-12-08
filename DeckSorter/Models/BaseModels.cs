using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeckSorter.Models.BaseModels
{
    public abstract class BaseDeck
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
    }
}
