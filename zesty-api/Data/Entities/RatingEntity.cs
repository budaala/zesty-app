namespace zesty_api.Data.Entities
{
    public class RatingEntity
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int Value { get; set; }
        public DateTime CreatedAt { get; set; }

        public static RatingEntity Create(int RecipeId, int UserId, int Value)
        {
            var entity = new RatingEntity
            {
                RecipeId = RecipeId,
                UserId = UserId,
                Value = Value,
                CreatedAt = DateTime.Now
            };

            return entity;
        }
    }
}
