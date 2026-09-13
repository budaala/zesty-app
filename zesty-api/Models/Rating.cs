namespace zesty_api.Models;

public class Rating
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public int UserId { get; init; }
    public int Value { get; init; }
    public DateTime CreatedAt { get; set; }
}