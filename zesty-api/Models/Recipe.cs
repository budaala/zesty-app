namespace zesty_api.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int MealTypeId { get; set; }
        public string MealTypeName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
