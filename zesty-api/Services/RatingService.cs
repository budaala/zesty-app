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
            var entity = RatingEntity.Create(rating.RecipeId, rating.UserId, rating.Value);
            db.Ratings.Add(entity);
            db.SaveChanges();
            rating.Id = entity.Id;
            return MapToDTO(entity);
        }

        public double GetAverageRating(int recipeId)
        {
            var ratings = db.Ratings.Where(r => r.RecipeId == recipeId);
            var sum = 0;
            foreach (var rating in ratings)
            {
                sum += rating.Value;
            }
            return sum / ratings.Count();
        }

        public int GetRating(int userId, int recipeId)
        {
            var rating = db.Ratings.FirstOrDefault(r => r.UserId == userId && r.RecipeId == recipeId);
            if (rating == null)
            {
                return 0;
            }
            return rating.Value;
            
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
