using System;
using Xunit;
using DeckSorter.Functionality;

namespace DeckSorterTests
{
    public class ManualShuffleEmulationTests
    {
        [Fact]
        public void NineCards()
        {
            string[] result = Shuffle.ManualShuffleEmulation(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            Assert.Equal(new string[] { "9", "7", "8", "1", "2", "3", "4", "5", "6" }, result);
        }

        [Fact]
        public void EightCards()
        {
            string[] result = Shuffle.ManualShuffleEmulation(new string[] { "1", "2", "3", "4", "5", "6", "7", "8" });
            Assert.Equal(new string[] { "8", "6", "7", "1", "2", "3", "4", "5" }, result);
        }

        [Fact]
        public void SevenCards()
        {
            string[] result = Shuffle.ManualShuffleEmulation(new string[] { "1", "2", "3", "4","5","6","7" });
            Assert.Equal(new string[] { "7", "5", "6", "1","2","3", "4" }, result);
        }
        [Fact]
        public void FourCards()
        {
            string[] result = Shuffle.ManualShuffleEmulation(new string[] { "1", "2", "3","4" });
            Assert.Equal(new string[] { "4","1", "2", "3" }, result);
        }
        [Fact]
        public void ThreeCards()
        {
            string[] result = Shuffle.ManualShuffleEmulation(new string[] { "1", "2", "3" });
            Assert.Equal(new string[] { "3", "1", "2" }, result);
        }
        [Fact]
        public void TwoCards()
        {
            string[] result = Shuffle.ManualShuffleEmulation(new string[] { "1", "2"});
            Assert.Equal(new string[] { "2","1" }, result);
        }
        [Fact]
        public void OneCard()
        {
            string[] result = Shuffle.ManualShuffleEmulation(new string[] { "1" });
            Assert.Equal(new string[] { "1" }, result);
        }
        [Fact]
        public void EmptyCards()
        {
            string[] result = Shuffle.ManualShuffleEmulation(new string[] { });
            Assert.Equal(new string[] { }, result);
        }
    }
}
