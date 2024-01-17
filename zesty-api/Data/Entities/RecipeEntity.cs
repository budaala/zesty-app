using Microsoft.Identity.Client;

namespace zesty_api.Data.Entities
{
    public class RecipeEntity
    {
        public int Id { get; set; }
        public int MealTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<RatingEntity> Ratings { get; set; }
        public MealTypeEntity MealType { get; set; }
        public UserEntity User { get; set; }

        public static RecipeEntity Create(int MealTypeId, string Title, string Description, string Ingredients, string Instructions, string ImageUrl, int UserId)
        {
            var entity = new RecipeEntity
            {
                MealTypeId = MealTypeId,
                Title = Title,
                Description = Description,
                Ingredients = Ingredients,
                Instructions = Instructions,
                ImageUrl = ImageUrl,
                UserId = UserId,
                CreatedAt = DateTime.Now
            };

            return entity;
        }
    }
}
