using Microsoft.EntityFrameworkCore;

namespace zesty_api.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<RecipeEntity> Recipes { get; set; }

        public ICollection<RecipeEntity> GetRecipes(DbContext dbContext)
        {
            return dbContext.Set<RecipeEntity>().Where(r => r.UserId == Id).ToList();
        }
    }
}
