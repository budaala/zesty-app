namespace zesty_api.Data.Entities;

public class RecipeEntity
{
    public int Id { get; init; }
    public int MealTypeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Ingredients { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int UserId { get; init; }
    public DateTime CreatedAt { get; init; }
    public ICollection<CommentEntity> Comments { get; init; } 
    public ICollection<RatingEntity> Ratings { get; init; }
    public MealTypeEntity MealType { get; init; }
    public UserEntity User { get; init; }

    public static RecipeEntity Create(int mealTypeId, string title, string description, string ingredients,
        string instructions, string imageUrl, int userId)
    {
        var entity = new RecipeEntity
        {
            MealTypeId = mealTypeId,
            Title = title,
            Description = description,
            Ingredients = ingredients,
            Instructions = instructions,
            ImageUrl = imageUrl,
            UserId = userId,
            CreatedAt = DateTime.Now
        };

        return entity;
    }
}