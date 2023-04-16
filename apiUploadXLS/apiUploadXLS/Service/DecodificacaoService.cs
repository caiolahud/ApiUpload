using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiUploadXLS.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecodificacaoService : ControllerBase
    {
        // GET: api/<DecodificacaoService>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DecodificacaoService>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DecodificacaoService>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DecodificacaoService>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DecodificacaoService>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
