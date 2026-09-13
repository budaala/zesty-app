using zesty_api.Data;
using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

// TODO: DO we need to implement this? Shouldn't we just return the score from all the ratings?

namespace zesty_api.Services;

public abstract class RatingService(DataContext db) : IRatingService
{
    public Rating AddRating(Rating rating)
    {
        var entity = RatingEntity.Create(rating.RecipeId, rating.UserId, rating.Value);
        db.Ratings.Add(entity);
        db.SaveChanges();
        rating.Id = entity.Id;
        return MapToDto(entity);
    }

    public double GetAverageRating(int recipeId)
    {
        var ratings = db.Ratings.Where(r => r.RecipeId == recipeId);
        double sum = 0;
        double length = ratings.Count();
        if (length == 0) return 0;
        foreach (var rating in ratings) sum += rating.Value;
        var average = sum / ratings.Count();
        return average;
    }

    public int GetRating(int userId, int recipeId)
    {
        var rating = db.Ratings.FirstOrDefault(r => r.UserId == userId && r.RecipeId == recipeId);
        return rating?.Value ?? 0;
    }

    private static Rating MapToDto(RatingEntity entity)
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