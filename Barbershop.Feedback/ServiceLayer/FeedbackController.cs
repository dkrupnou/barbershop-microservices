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

        [HttpGet("{barberId}/rating")]
        public async Task<IActionResult> GetRating(Guid barberId)
        {
            var barberRating = _service.GetBarberRating(barberId);
            if (barberRating == null)
                return NotFound();

            var ratingModel = barberRating.ToBarberRatingModel();
            return Ok(ratingModel);
        }

        [HttpGet("{barberId}")]
        public async Task<IActionResult> GetFeedback(Guid barberId)
        {
            var barberFeedback = _service.GetBarberFeedback(barberId);
            if (barberFeedback == null || !barberFeedback.Any())
                return NotFound();

            var feedbackModel = barberFeedback.Select(x => x.ToBarberFeedbackModel()).ToArray();
            return Ok(feedbackModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BarberFeedbackEvaluationModel model)
        {
            _service.StoreFeedback(model.BarberId, model.Body, model.Rating);
            return Ok();
        }
    }
}