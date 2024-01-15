using zesty_api.Models;

namespace zesty_api.Interfaces
{
    public interface IRatingService
    {
        Rating AddRating(Rating rating);
        double GetRating(int Id);
    }
}
