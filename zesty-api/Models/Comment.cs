namespace zesty_api.Models;

public class Comment
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public int UserId { get; init; }
    public string? Username { get; set; }
    public string Content { get; init; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}