using System;
using System.Linq;
using System.Threading.Tasks;
using Barbershop.Feedback.BusinessLayer;
using Barbershop.Feedback.ServiceLayer.Model;
using Barbershop.Feedback.ServiceLayer.Util;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.Feedback.ServiceLayer
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                return BadRequest($"{id} has incorrect format");

            var barberFeedback = _service.GetBarberFeedback(guid);
            if (barberFeedback == null || !barberFeedback.Any())
                return NotFound();

            var feedbackModel = barberFeedback.Select(x => x.ToBarberFeedbackModel()).ToArray();
            return Ok(feedbackModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BarberFeedbackEvaluationModel model)
        {
            Guid guid;
            if (!Guid.TryParse(model.BarberId, out guid))
                return BadRequest($"{model.BarberId} has incorrect format");

            _service.PostBarberFeedback(guid, model.Body, model.Rating);
            return Ok();
        }
    }
}