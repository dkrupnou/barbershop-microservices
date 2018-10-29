using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barbershop.Barbers.ServiceLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.Barbers.ServiceLayer
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        private static IDictionary<string, BarberModel> _barbers = new Dictionary<string, BarberModel>();

        // GET api/barbers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var barbers = _barbers.Values.ToArray();
            return Ok(barbers);
        }

        // GET api/barbers
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (!_barbers.ContainsKey(id))
                return NotFound();

            return Ok(_barbers[id]);
        }

        // POST api/barbers
        [HttpPost]
        public void Post([FromBody] BarberModel model)
        {
            model.Id = Guid.NewGuid().ToString("N");
            _barbers.Add(model.Id, model);
        }

        // PUT api/barbers/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] BarberModel model)
        {
            if (!_barbers.ContainsKey(id))
                return;

            model.Id = id;
            _barbers[id] = model;
        }

        // DELETE api/barbers/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            if (!_barbers.ContainsKey(id))
                return;

            _barbers.Remove(id);
        }
    }
}