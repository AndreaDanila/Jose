using Library.Lib.DAL;
using Library.Lib.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        ClientsRepository Repo { get; set; }

        public ClientsController()
        {
            Repo = new ClientsRepository();
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return Repo.GetAll();
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public Client Get(Guid id)
        {
            return Repo.Get(id);
        }

        // POST api/<ClientsController>
        [HttpPost]
        public ClientValidationsTypes Post([FromBody] Client client)
        {
            return Repo.Add(client);
        }

        // PUT api/<ClientsController>/5
        [HttpPut]
        public ClientValidationsTypes Put([FromBody] Client client)
        {
            return Repo.Update(client);
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public ClientValidationsTypes Delete(Guid id)
        {
            return Repo.Delete(id);
        }
    }
}
