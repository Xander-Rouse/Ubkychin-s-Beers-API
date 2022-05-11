using System.Collections.Generic;
using BeersLib;
using Microsoft.AspNetCore.Mvc;
using BeersApi.Handlers;

namespace BeersApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class BeersController : ControllerBase {
        DbHandler dbh = new DbHandler();

        public BeersController() {

        }

        [HttpGet]        
        public List<Beer> Get () {
            return this.dbh.GetAllBeers();
        }

        [HttpGet("{name}")]
        public Beer GetBeer(string name) {
            return this.dbh.GetBeerByName(name);
        }
        
        [HttpPost]
        public int Post(Beer newBeer) {
            // TODO:  this needs to use the database handler to add a new
            return this.dbh.addNewBeer(newBeer); 
        }
    }

}
