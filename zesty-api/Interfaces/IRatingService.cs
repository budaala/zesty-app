using zesty_api.Models;

namespace zesty_api.Interfaces
{
    public interface IRatingService
    {
        Task<Rating> AddRating(Rating rating);
        Task<int> GetRating(int UserId);
        Task<double> GetAverageRating(int recipeId);
    }
}
