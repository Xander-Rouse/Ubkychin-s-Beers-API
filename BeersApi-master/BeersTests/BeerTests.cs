using System;
using BeersLib;
using Xunit;

namespace BeersTests {
    public class BeerTests {

        Beer beer1;
        Beer beer2;
        Beer beer3;

        public BeerTests () {
            beer1 = new Beer ("Fosters", "CUB", 4.5f, 12, 350, 6f);
            beer2 = new Beer ("VB", "CUB", 4.5f, 16, 375, 5f);
            beer3 = new Beer ("Colonial Pale", "Colonial Brewing", 4.4f, 35, 375, 7f);
        }

        [Theory]
        [InlineData (340, 10, true)]
        [InlineData (350, 0, false)]
        [InlineData (0, 350, true)]
        [InlineData (0, 360, true)]
        [InlineData (350, -10, false)]
        public void Beer1_DrinkTest (int expected, int amountDrunk, bool expectedOpen) {
            beer1.Drink (amountDrunk);
            Assert.Equal (expected, beer1.Amount);
            Assert.Equal (expectedOpen, beer1.Open);
        }

        [Theory]
        [InlineData (0, 375, true)]
        [InlineData (255, 120, true)]
        [InlineData (375, 0, false)]
        [InlineData (0, 1000, true)]
        [InlineData (375, -10, false)]
        public void Beer2_DrinkTest (int expected, int amountDrunk, bool expectedOpen) {
            beer2.Drink (amountDrunk);
            Assert.Equal (expected, beer2.Amount);
            Assert.Equal (expectedOpen, beer2.Open);
        }

        [Theory]
        [InlineData (375, 0, false)]
        [InlineData (300, 75, true)]
        [InlineData (200, 175, true)]
        [InlineData (0, 376, true)]
        [InlineData (375, -10, false)]
        public void Beer3_DrinkTest (int expected, int amountDrunk, bool expectedOpen) {
            beer3.Drink (amountDrunk);
            Assert.Equal (expected, beer3.Amount);
            Assert.Equal (expectedOpen, beer3.Open);
        }

        [Fact]
        public void OpenBeerTest () {
            beer1.OpenBeer ();
            Assert.Equal (true, beer1.Open);
            Assert.Equal (false, beer2.Open);
            Assert.Equal (false, beer3.Open);
        }
    }
}