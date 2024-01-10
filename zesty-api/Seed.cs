using zesty_api.Data;
using zesty_api.Data.Entities;

namespace zesty_api
{
    public class Seed
    {

        private readonly DataContext context;
        public Seed(DataContext context)
        {
            this.context = context;
        }

        public void SeedDataContext()
        {
            if (!context.Users.Any())
            {
                var users = new List<UserEntity>
                 {
                     new UserEntity
                     {
                         UserName = "test",
                         Email = "test@test",
                         PasswordHash = "test"
                     },
                     new UserEntity
                     {
                         UserName = "test2",
                         Email = "test2@test",
                         PasswordHash = "test2"
                     }
                 };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (!context.MealTypes.Any())
            {
                var mealTypes = new List<MealTypeEntity>
                 {
                     new MealTypeEntity
                     {
                         Name = "Breakfast"
                     },
                     new MealTypeEntity
                     {
                         Name = "Lunch"
                     },
                     new MealTypeEntity
                     {
                         Name = "Dinner"
                     },
                     new MealTypeEntity
                     {
                         Name = "Snack"
                     }
                 };

                context.MealTypes.AddRange(mealTypes);
                context.SaveChanges();
            }

            if (!context.Recipes.Any())
            {
                var recipes = new List<RecipeEntity>
                 {
                     new RecipeEntity
                     {
                         Title = "Test Recipe",
                         Description = "Test Description",
                         Ingredients = "Test Ingredients",
                         Instructions = "Test Instructions",
                         ImageUrl = "Test ImageUrl",
                         UserId = 1,
                         MealTypeId = 1
                     },
                     new RecipeEntity
                     {
                         Title = "Test Recipe 2",
                         Description = "Test Description 2",
                         Ingredients = "Test Ingredients 2",
                         Instructions = "Test Instructions 2",
                         ImageUrl = "Test ImageUrl 2",
                         UserId = 2,
                         MealTypeId = 2
                     }
                };
             
                context.Recipes.AddRange(recipes);
                context.SaveChanges();
            }
        }
    }
}
