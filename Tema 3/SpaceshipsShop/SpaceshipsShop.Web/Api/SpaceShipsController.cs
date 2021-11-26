using Microsoft.AspNetCore.Mvc;
using SpaceshipsShop.Lib.Models;
using SpaceshipsShop.Web.DAL;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceshipsShop.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceShipsController : ControllerBase
    {
        // GET: api/<SpaceShipsController>
        [HttpGet]
        public IEnumerable<SpaceShip> Get()
        {
            var dbContext = new SpaceShipsShopDbContext();

            if (dbContext.SpaceShips.Count() == 0)
            {
                var nave1 = new SpaceShip()
                {
                    Id = Guid.NewGuid(),
                    Brand = "Pegasus",
                    FTLFactor = 10,
                    PassengersCapacity = 20,
                    Color = "Red",
                    Password = "Atenea.1234"
                };

                var nave2 = new SpaceShip()
                {
                    Id = Guid.NewGuid(),
                    Brand = "Phoenix",
                    FTLFactor = 8,
                    PassengersCapacity = 50,
                    Color = "Black",
                    Password = "Lolo.1234"
                };

                dbContext.SpaceShips.Add(nave1);
                dbContext.SpaceShips.Add(nave2);

                dbContext.SaveChanges();
            }

            return dbContext.SpaceShips.ToList();

        }

        // GET api/<SpaceShipsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpaceShipsController>
        [HttpPost]
        public bool Post([FromBody] SpaceShip item)
        {
            using(var dbContext = new SpaceShipsShopDbContext())
            {
                if (item.Id != default && dbContext.SpaceShips.Any(x=>x.Id == item.Id))
                {
                    return false;
                }

                if (item.Id == default)
                    item.Id = Guid.NewGuid();

                dbContext.Add(item);

                dbContext.SaveChanges();
                return true;
            }
        }

        // PUT api/<SpaceShipsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpaceShipsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
