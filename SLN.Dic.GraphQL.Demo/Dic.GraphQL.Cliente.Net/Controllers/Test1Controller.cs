using Dic.GraphQL.Cliente.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dic.GraphQL.Cliente.Net.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Test1Controller : ControllerBase
    {
        private readonly OwnerConsumer _consumer;
        public Test1Controller(OwnerConsumer consumer)
        {
            _consumer = consumer;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var owners = await _consumer.GetAllOwners();
            return Ok(owners);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOwner(OwnerInput model)
        {
            var entidad = await _consumer.CreateOwner(model);
            return Ok(entidad);
        }

        [HttpGet]
        public async Task<IActionResult> GetOwner(string id)
        {
            var entidad = await _consumer.GetOwner(Guid.Parse(id));
            return Ok(entidad);
        }
    }
}
