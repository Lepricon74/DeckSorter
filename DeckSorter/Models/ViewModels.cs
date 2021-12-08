using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckSorter.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

//Модели-представлений
namespace DeckSorter.Models.ViewModels
{
    public class DeckViewModel : BaseDeck
    {
        public string[] Cards { get; set; }
    }

    public class DeckShortViewModel : BaseDeck{}

    public class DeckCreateViewModel
    {
        [Required]
        [Display(Name = "Размер колоды")]
        public int Size { get; set; }

        [Required]
        [Display(Name = "Название колоды")]
        public string Name { get; set; }
    }
}
