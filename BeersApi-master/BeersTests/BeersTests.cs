using System;
using System.Collections.Generic;
using BeersLib;
using Xunit;

namespace BeersTests
{
    public class BeersTests
    {
        Beers beersTestList1;
        Beers beersTestList2;
        Beers beersTestListAdded;
        Beers beersTestListEmpty;
        Beer newBeer;

        public BeersTests() {
            this.beersTestList1 = new Beers();
            this.beersTestList1.BeersList = new List<Beer>();
            this.beersTestList1.BeersList.Add(new Beer ("Fosters", "CUB", 4.5f, 12, 350, 6f));
            this.beersTestList1.BeersList.Add(new Beer ("VB", "CUB", 4.6f, 16, 375, 5f));
            this.beersTestList1.BeersList.Add(new Beer ("VB2", "CUB", 4.6f, 16, 375, 5f));
            this.beersTestList1.BeersList.Add(new Beer ("Colonial Pale", "Colonial Brewing", 4.4f, 35, 375, 7f));
            this.beersTestList1.BeersList.Add(new Beer ("Colonial NotPale", "Colonial Brewing", 4.4f, 35, 375, 7f));

            this.beersTestList2 = new Beers();
            this.beersTestList2.BeersList = new List<Beer>();
            this.beersTestList2.BeersList.Add(new Beer ("Fosters", "CUB", 4.5f, 12, 350, 6f));
            this.beersTestList2.BeersList.Add(new Beer ("VB", "CUB", 4.6f, 16, 375, 5f));
            this.beersTestList2.BeersList.Add(new Beer ("Colonial Pale", "Colonial Brewing", 4.4f, 35, 375, 7f));

            this.beersTestListAdded = new Beers();
            this.beersTestListAdded.BeersList = new List<Beer>();
            this.beersTestListAdded.BeersList.Add(new Beer ("Fosters", "CUB", 4.5f, 12, 350, 6f));
            this.beersTestListAdded.BeersList.Add(new Beer ("VB", "CUB", 4.6f, 16, 375, 5f));
            this.beersTestListAdded.BeersList.Add(new Beer ("Colonial Pale", "Colonial Brewing", 4.4f, 35, 375, 7f));
            this.beersTestListAdded.BeersList.Add(new Beer("Coopers", "Coopers", 3.5f, 5, 375, 5.5f));

            this.beersTestListEmpty = new Beers();
            this.beersTestListEmpty.BeersList = new List<Beer>();

            newBeer = new Beer("Coopers", "Coopers", 3.5f, 5, 375, 5.5f);
            
        }

        // [Fact]
        // public void EmptyBeersListTests() {
        //     Assert.Null(this.beersTestListEmpty.GetLightestBeers());
        //     Assert.Null(this.beersTestListEmpty.GetHeaviestBeers());

        //     Assert.Equal(this.beersTestList1.BeersList[0], this.beersTestList1.CompareAbv(null, this.beersTestList1.BeersList[0]));
        //     Assert.Equal(this.beersTestList1.BeersList[0], this.beersTestList1.CompareAbv(this.beersTestList1.BeersList[0], null));

        // }

        [Fact]
         public void GetLightestBeerTest() {
            List<Beer> lightestBeers = new List<Beer>();
            lightestBeers.Add(this.beersTestList1.BeersList[3]);
            lightestBeers.Add(this.beersTestList1.BeersList[4]);
            Assert.Equal(lightestBeers, this.beersTestList1.GetLightestBeers());

            lightestBeers = new List<Beer>();
            lightestBeers.Add(this.beersTestList2.BeersList[2]);
            Assert.Equal(lightestBeers, this.beersTestList2.GetLightestBeers());
        }

        [Fact]
        public void GetHeaviestBeerTest() {
            List<Beer> heaviestBeers = new List<Beer>();
            heaviestBeers.Add(this.beersTestList1.BeersList[1]);
            heaviestBeers.Add(this.beersTestList1.BeersList[2]);
            Assert.Equal(heaviestBeers, this.beersTestList1.GetHeaviestBeers());

            heaviestBeers = new List<Beer>();
            heaviestBeers.Add(this.beersTestList2.BeersList[1]);
            Assert.Equal(heaviestBeers, this.beersTestList2.GetHeaviestBeers());
        }

        [Theory]
        [InlineData(1,0,1)]
        [InlineData(0,4,0)]
        public void CompareAbvTest(int expected, int index1, int index2) {
            Assert.Equal(this.beersTestList1.BeersList[expected], 
            this.beersTestList1.CompareAbv(this.beersTestList1.BeersList[index1], this.beersTestList1.BeersList[index2]));
        }

        [Fact]
        public void AddBeerTest() {
            this.beersTestList2.AddBeer(newBeer);
            
            //Assert.Equal(this.beersTestListAdded.BeersList, this.beersTestList2.BeersList);
            Assert.Equal(4, this.beersTestList2.BeersList.Count);
        }

        [Fact]
        public void RemoveBeerTest() {
            Beer remove = new Beer ("Fosters", "CUB", 4.5f, 12, 350, 6f);
            this.beersTestList1.RemoveBeer(remove);
            Assert.Equal(4, beersTestList1.BeersList.Count);

            remove = new Beer ("Glosters", "CBU", 4.5f, 12, 350, 6f);
            this.beersTestList2.RemoveBeer(remove);
            Assert.Equal(3, beersTestList2.BeersList.Count);

            this.beersTestListEmpty.RemoveBeer(remove);
            Assert.Equal(0, beersTestListEmpty.BeersList.Count);
        }

        [Fact]
        public void UpdateBeerTest() {
            Beer update = new Beer ("Fosters", "CUB", 4.5f, 12, 350, 7f);
            this.beersTestList1.UpdateBeer(update);
            Assert.Equal(7f, this.beersTestList1.BeersList[0].Cost);

            update = new Beer ("Glosters", "CBU", 4.5f, 12, 350, 7f);
            this.beersTestList2.UpdateBeer(update);
            Assert.Equal(7f, this.beersTestList1.BeersList[0].Cost);
        }

        [Theory]
        [InlineData(0, "Fosters")]
        [InlineData(1, "VB")]
        public void GetBeerByNameTest(int expected, string name) {
            Assert.Equal(this.beersTestList2.BeersList[expected], this.beersTestList2.GetBeerByName(name));
        }

        [Fact]
        public void GetBeerByNameNotExistTest() {
            Assert.Null(this.beersTestList2.GetBeerByName("Imaginary"));
        }

    }
}