using zesty_api.Data;
using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

/// TODO: DO we need to implement this? Shouldn't we just return the score from all the ratings?

namespace zesty_api.Services
{
    public class RatingService : IRatingService
    {
        private readonly DataContext db;

        public RatingService(DataContext db)
        {
            this.db = db;
        }

        public Rating AddRating(Rating rating)
        {
            throw new NotImplementedException();
        }

        public double GetRating(int Id)
        {
            throw new NotImplementedException();
        }

        public static Rating MapToDTO(RatingEntity entity)
        {
            return new Rating
            {
                Id = entity.Id,
                RecipeId = entity.RecipeId,
                UserId = entity.UserId,
                Value = entity.Value,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
