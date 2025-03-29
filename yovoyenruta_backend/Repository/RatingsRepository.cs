using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yovoyenruta_backend.Data.Entities;

namespace yovoyenruta_backend.Repository
{
    public class RatingsRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Rating>>> GetRatings()
        {
            try
            {
                return await _context.ratings.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult<List<Rating>>> GetRatingsByOperator(Guid idOperator)
        {
            try
            {
                return await _context.ratings.Where(x => x.operator_id == idOperator).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Rating Show(Guid id)
        {
            try
            {
                var rating = _context.ratings.FirstOrDefault(rating => rating.id == id);

                if (rating == null)
                    throw new Exception("No se encontró la calificacion especificada");

                return rating;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ActionResult<Rating>> Create(Rating rating)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                Rating newRating = new Rating()
                {
                    id = Guid.NewGuid(),
                    operator_id = rating.operator_id,
                    stars = rating.stars,
                    comment= rating.comment,
                    date = DateTime.Now,

                };

                _context.ratings.Add(newRating);
                _context.SaveChanges();
                await transaction.CommitAsync();

                return newRating;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

    }
}
