using Microsoft.AspNetCore.Mvc;

namespace Math.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        // GET: api/Quiz
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Quiz/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Quiz
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Quiz/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Quiz/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
