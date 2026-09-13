using zesty_api.Data;
using zesty_api.Data.Entities;

namespace zesty_api;

public class Seed
{
    private readonly DataContext _context;

    public Seed(DataContext context)
    {
        _context = context;
    }

    public void SeedDataContext()
    {
        if (!_context.Users.Any())
        {
            var users = new List<UserEntity>
            {
                new()
                {
                    Username = "test",
                    Email = "test@test",
                    Password = "test"
                },
                new()
                {
                    Username = "test2",
                    Email = "test2@test",
                    Password = "test2"
                }
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        if (!_context.MealTypes.Any())
        {
            var mealTypes = new List<MealTypeEntity>
            {
                new()
                {
                    Name = "Breakfast"
                },
                new()
                {
                    Name = "Lunch"
                },
                new()
                {
                    Name = "Dinner"
                },
                new()
                {
                    Name = "Snack"
                }
            };

            _context.MealTypes.AddRange(mealTypes);
            _context.SaveChanges();
        }

        if (_context.Recipes.Any()) return;
        var recipes = new List<RecipeEntity>
        {
            new()
            {
                Title = "Test Recipe",
                Description = "Test Description",
                Ingredients = "Test Ingredients",
                Instructions = "Test Instructions",
                ImageUrl = "Test ImageUrl",
                UserId = 1,
                MealTypeId = 1
            },
            new()
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

        _context.Recipes.AddRange(recipes);
        _context.SaveChanges();
    }
}