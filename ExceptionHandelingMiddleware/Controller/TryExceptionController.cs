

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
    }
}
