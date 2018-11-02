using System;
using System.Linq;
using System.Threading.Tasks;
using Barbershop.Barbers.BusinessLayer;
using Barbershop.Barbers.ServiceLayer.Model;
using Barbershop.Barbers.ServiceLayer.Util;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.Barbers.ServiceLayer
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        private readonly IBarbersService _service;

        public BarbersController(IBarbersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var barbersDetails = await _service.GetBarbersDetails();
            var barbersDetailsModel = barbersDetails.Select(x => x.ToBarberDetailsModel());
            return Ok(barbersDetailsModel);
        }

        [HttpGet("{barberId}")]
        public async Task<IActionResult> Get(Guid barberId)
        {
            var barberDetails = await _service.GetBarberDetails(barberId);
            if (barberDetails == null)
                return NotFound();

            var barberDetailsModel = barberDetails.ToBarberDetailsModel();
            return Ok(barberDetailsModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] BarberRegistrationModel model)
        {
            var barberId = await _service.RegisterBarber(model.FirstName, model.LastName, model.Email);
            var idString = barberId.ToString("N");
            return Ok(idString);
        }

        [HttpDelete("{barberId}")]
        public async Task<IActionResult> Delete(Guid barberId)
        {
            await _service.RemoveBarber(barberId);
            return Ok();
        }
    }
}