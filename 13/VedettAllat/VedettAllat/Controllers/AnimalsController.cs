using Microsoft.AspNetCore.Mvc;
using VedettAllat.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VedettAllat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        readonly IVedettAllat67 _13;

        public AnimalsController(IVedettAllat67 _13)
        {
            this._13 = _13;
        }

        // GET: api/<AnimalsController>
        [HttpGet]
        public IEnumerable<VedettAllat.Model.VedettAllat> Get()
        {
            return _13.GetAll();
        }

        // GET api/<AnimalsController>/5
        [HttpGet("{id}")]
        public VedettAllat.Model.VedettAllat Get(int id)
        {
            return _13.GetById(id) ?? throw new Exception("I hate diggers");
        }

        // POST api/<AnimalsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnimalsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnimalsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
