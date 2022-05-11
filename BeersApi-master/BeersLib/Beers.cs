using System;
using System.Collections.Generic;
using System.Linq;

namespace BeersLib {
    public class Beer {

        public string Name { get; set; }
        public string Brewery { get; set; }
        // Abv: Alcohol By Volume
        public float Abv { get; set; }
        // IBU: Internation Bitterness Unit
        public uint Ibu { get; set; }
        public int Amount { get; set; }
        public float Cost { get; set; }
        public bool Open { get; set; }

        public Beer () {}
        public Beer (string name, string brewery, float abv, uint ibu, int amount, float cost) {
            this.Name = name;
            this.Brewery = brewery;
            this.Abv = abv;
            this.Ibu = ibu;
            this.Amount = amount;
            this.Cost = cost;
            this.Open = false;
        }

        public void Drink (int amount) {
            if(amount >= this.Amount) {
                this.Amount = 0;
            } else if (amount == 0) {
                return;
            } else if (amount < 0) {
                return;
            } else {
                this.Amount -= amount;
            }

            if(!this.Open) {
                this.OpenBeer();
            }
        }

        public void OpenBeer () {
            this.Open = true;
        }
    }

    public class Beers {

        public List<Beer> BeersList { get; set; }

        public Beers () {
            this.BeersList = new List<Beer>();
            this.BeersList.Add(new Beer ("Fosters", "CUB", 4.5f, 12, 350, 6f));
            this.BeersList.Add(new Beer ("VB", "CUB", 4.5f, 16, 375, 5f));
            this.BeersList.Add(new Beer ("Colonial Pale", "Colonial Brewing", 4.4f, 35, 375, 7f));
            this.BeersList.Add(new Beer("Coopers", "Coopers", 3.5f, 5, 375, 5.5f));
        }

        public Beers (List<Beer> beersList) {
            BeersList = beersList;
        }

        public List<Beer> GetLightestBeers() {
            if(this.BeersList == null) {
                return null;
            }

            if(this.BeersList.Count == 0) {
                return null;
            }

            float currentLightestAbv = this.BeersList[0].Abv;
            List<Beer> lightest = new List<Beer>();
            
            // find lightest Abv
            foreach(Beer b in this.BeersList) {
                if(b.Abv < currentLightestAbv) {
                    currentLightestAbv = b.Abv;
                }
            }

            // find all beers with Abv
            foreach (Beer b in this.BeersList) {
                if(b.Abv == currentLightestAbv) {
                    lightest.Add(b);
                }
            }

            return lightest;
        }

        public List<Beer> GetHeaviestBeers() {
            if(this.BeersList == null) {
                return null;
            }

            if(this.BeersList.Count == 0) {
                return null;
            }

            // LINQ libraries
            float maxAbv = this.BeersList.Max<Beer>(beer => beer.Abv);
            List<Beer> heaviest = this.BeersList.FindAll(beer => beer.Abv == maxAbv);

            return heaviest;
        }

        // return the heavier beer.  If equal, return beer1
        public Beer CompareAbv(Beer beer1, Beer beer2) {
            if(beer2.Abv > beer1.Abv) {
                return beer2;
            } 

            return beer1;
            
        }

        public void AddBeer(Beer newBeer) {
            if(newBeer != null) {
                this.BeersList.Add(newBeer);
            }
        }

        public void RemoveBeer(Beer removeBeer) {
            this.BeersList.Remove(this.GetBeerByName(removeBeer.Name));
        }

        public void UpdateBeer(Beer updatedBeer) {
            // 1. Find the equivalent beer in the list - for
            // 2, Replace if with updatedBeer

            for(int i=0; i < this.BeersList.Count; i++) {
                if(this.BeersList[i].Name == updatedBeer.Name) {
                    this.BeersList[i] = updatedBeer;
                    return;
                }
            }

        }

        public Beer GetBeerByName(string name) {
            foreach(Beer b in this.BeersList) {
                if(b.Name == name) {
                    return b;
                }
            }
            return null;
        }

    }
}