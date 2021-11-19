using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var std1 = new Student()
            {
                Id = Guid.NewGuid(),
                Name = "Lolo",
                Surname1 = "García",
                Email = "a@a.com",
                Password = "1234"
            };

            var std2 = new Student()
            {
                Id = Guid.NewGuid(),
                Name = "Marta",
                Surname1 = "Pérez",
                Email = "m@m.com",
                Password = "6234"
            };

            return new List<Student>() { std1, std2 };
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
