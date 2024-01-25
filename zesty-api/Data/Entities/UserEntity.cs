using Microsoft.EntityFrameworkCore;

namespace zesty_api.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<RecipeEntity> GetRecipes(DbContext dbContext)
        {
            return dbContext.Set<RecipeEntity>().Where(r => r.UserId == Id).ToList();
        }

        public static UserEntity Create(string username, string email, string password)
        {
            return new UserEntity
            {
                Username = username,
                Email = email,
                Password = password
            };
        }
    }
}
