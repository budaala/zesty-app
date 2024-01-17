using zesty_api.Models;

namespace zesty_api.Interfaces
{
    public interface IRatingService
    {
        Rating AddRating(Rating rating);
        int GetRating(int userId, int recipeId);
        double GetAverageRating(int recipeId);
    }
}
