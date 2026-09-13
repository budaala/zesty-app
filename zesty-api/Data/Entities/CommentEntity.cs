namespace zesty_api.Data.Entities;

public class CommentEntity
{
    public int Id { get; init; }
    public int RecipeId { get; init; }
    public int UserId { get; init; }
    public string Content { get; init; }
    public DateTime CreatedAt { get; init; }
    public UserEntity User { get; set; }

    public static CommentEntity Create(int recipeId, int userId, string content)
    {
        var entity = new CommentEntity
        {
            RecipeId = recipeId,
            UserId = userId,
            Content = content,
            CreatedAt = DateTime.Now
        };

        return entity;
    }
}