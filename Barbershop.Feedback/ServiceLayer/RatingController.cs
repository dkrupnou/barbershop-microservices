using System;
using System.Linq;
using System.Threading.Tasks;
using Barbershop.Feedback.BusinessLayer;
using Barbershop.Feedback.ServiceLayer.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Barbershop.Feedback.ServiceLayer
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public RatingController(IFeedbackService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ratings = _service.GetBarberRatings();
            if (ratings == null || !EnumerableExtensions.Any(ratings))
                return NoContent();

            var ratingModels = ratings.Select(x => x.ToBarberRatingModel()).ToArray();
            return Ok(ratingModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                return BadRequest($"{id} has incorrect format");

            var barberRating = _service.GetBarberRating(guid);
            if (barberRating == null)
                return NotFound();

            var ratingModel = barberRating.ToBarberRatingModel();
            return Ok(ratingModel);
        }
    }
}