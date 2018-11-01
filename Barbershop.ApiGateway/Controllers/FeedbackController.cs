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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _feedbackClient.GetBarberFeedback(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BarberFeedbackEvaluationModel model)
        {
            await _feedbackClient.PostBarberFeedback(model);
            return Ok();
        }
    }
}