namespace zesty_api.Data.Entities;

public class RatingEntity
{
    public int Id { get; init; }
    public int RecipeId { get; init; }
    public int UserId { get; init; }
    public int Value { get; init; }
    public DateTime CreatedAt { get; init; }

    public static RatingEntity Create(int recipeId, int userId, int value)
    {
        var entity = new RatingEntity
        {
            RecipeId = recipeId,
            UserId = userId,
            Value = value,
            CreatedAt = DateTime.Now
        };

        return entity;
    }
}