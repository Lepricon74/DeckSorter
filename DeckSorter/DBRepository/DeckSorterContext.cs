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
        public DbSet<Deck> Decks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Deck>().HasKey(u => new { u.Id });
            modelBuilder.Entity<Deck>().Property(u => u.Id).UseIdentityAlwaysColumn();
        }
    }
}
