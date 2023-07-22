

using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandelingMiddleware.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TryExceptionController : ControllerBase
    {
        // GET: api/<TryExceptionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new Exception("exception");
            return new string[] { "value1", "value2" };
        }

        // GET api/<TryExceptionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
          return "value";   
        }

        // POST api/<TryExceptionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TryExceptionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TryExceptionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
