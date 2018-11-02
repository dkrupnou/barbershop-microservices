using System;
using System.Threading.Tasks;
using Barbershop.ApiGateway.Services.Feedback;
using Barbershop.ApiGateway.Services.Feedback.Model;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackClient _feedbackClient;

        public FeedbackController(IFeedbackClient feedbackClient)
        {
            _feedbackClient = feedbackClient;
        }

        [HttpGet("{barberId}/rating")]
        public async Task<IActionResult> GetBarberRating(Guid barberId)
        {
            var result = await _feedbackClient.GetBarberRating(barberId);
            return Ok(result);
        }

        [HttpGet("{barberId}")]
        public async Task<IActionResult> GetBarberFeedback(Guid barberId)
        {
            var result = await _feedbackClient.GetBarberFeedback(barberId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BarberFeedbackEvaluationModel model)
        {
            await _feedbackClient.StoreBarberFeedback(model);
            return Ok();
        }
    }
}