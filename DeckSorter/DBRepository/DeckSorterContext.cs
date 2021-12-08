using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeckSorter.Models.DBModels;

namespace DeckSorter.DBRepository
{
    public class DeckSorterContext : DbContext
    {
        public DeckSorterContext(DbContextOptions<DeckSorterContext> options) : base(options){}
        //Таблица Decks
        public DbSet<Deck> Decks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Устанавливаем поле ID в качестве первичного ключа 
            modelBuilder.Entity<Deck>().HasKey(u => new { u.Id });
            //Включаем авто-инкремент для поля ID
            modelBuilder.Entity<Deck>().Property(u => u.Id).UseIdentityAlwaysColumn();
        }
    }
}
