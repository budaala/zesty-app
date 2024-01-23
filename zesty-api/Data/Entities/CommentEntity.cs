namespace zesty_api.Data.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public static CommentEntity Create(int RecipeId, int UserId, string Content)
        {
            var entity = new CommentEntity
            {
                RecipeId = RecipeId,
                UserId = UserId,
                Content = Content,
                CreatedAt = DateTime.Now
            };

            return entity;
        }
    }
}
