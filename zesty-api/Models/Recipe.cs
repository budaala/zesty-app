namespace zesty_api.Models;

public class Recipe
{
    public int Id { get; set; }
    public int MealTypeId { get; init; }
    public string MealTypeName { get; set; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Ingredients { get; init; } = string.Empty;
    public string Instructions { get; init; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int UserId { get; init; }
    public string Username { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}