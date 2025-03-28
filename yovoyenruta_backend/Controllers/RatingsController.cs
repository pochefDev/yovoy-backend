using Microsoft.AspNetCore.Mvc;
using yovoyenruta_backend.Data.Entities;
using yovoyenruta_backend.Repository;

namespace yovoyenruta_backend.Controllers
{
    [Route("api/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly RatingsRepository repository;

        public RatingsController(RatingsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRatings()
        {
            try
            {
                var rating = await repository.GetRatings();
                return Ok(rating);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRating(Guid id)
        {
            try
            {
                var rating = repository.Show(id);

                return Ok(rating);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRating(Rating rating)
        {
            try
            {
                var newRating = await repository.Create(rating);
                return Created("api/ratings", newRating);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }
    }
}
