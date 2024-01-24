using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using zesty_api.Data;
using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

namespace zesty_api.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly DataContext db;

        public RecipesService(DataContext db)
        {
            this.db = db;
        }

        public Recipe CreateRecipe(Recipe recipe)
        {
            var recipeEntity = RecipeEntity.Create(recipe.MealTypeId, recipe.Title, recipe.Description, recipe.Ingredients, recipe.Instructions, recipe.ImageUrl, recipe.UserId );
            db.Recipes.Add(recipeEntity);
            db.SaveChanges();
            recipe.Id = recipeEntity.Id;
            return MapToDTO(recipeEntity);
        }

        public Task DeleteRecipe(int recipeId)
        {
            var recipe = db.Recipes.Find(recipeId) ?? throw new Exception("Recipe not found");
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return Task.CompletedTask;
            
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            var recipes = db.Recipes.Include(r => r.MealType).Include(r => r.User).ToList() ?? throw new Exception("We were not able to load recipes");
            return recipes.Select(MapToDTO);
        }

        public Recipe GetRecipe(int recipeId)
        {
            var recipe = db.Recipes
                .Include(r => r.MealType)
                .Include(r => r.User)
                .SingleOrDefault(r => r.Id == recipeId) ?? throw new Exception("Recipe not found");
            return MapToDTO(recipe); 
        }

        public Task UpdateRecipe(Recipe recipe)
        {
            var recipeEntity = db.Recipes.Find(recipe.Id) ?? throw new Exception("Recipe not found");
            recipeEntity.MealTypeId = recipe.MealTypeId;
            recipeEntity.Title = recipe.Title;
            recipeEntity.Description = recipe.Description;
            recipeEntity.Ingredients = recipe.Ingredients;
            recipeEntity.Instructions = recipe.Instructions;
            recipeEntity.ImageUrl = recipe.ImageUrl;
            db.SaveChanges();
            return Task.CompletedTask;
            
        }

        public IEnumerable<MealType> GetMealTypes()
        {
            var mealTypes = db.MealTypes.ToList() ?? throw new Exception("We were not able to load meal types");
            return mealTypes.Select(MapToDTO);
        }

        public static Recipe MapToDTO(RecipeEntity entity)
        {
            return new Recipe
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Username = entity.User.Username ?? "",
                Title = entity.Title,
                MealTypeId = entity.MealTypeId,
                MealTypeName = entity.MealType.Name ?? "",
                Description = entity.Description,
                Ingredients = entity.Ingredients,
                Instructions = entity.Instructions,
                CreatedAt = entity.CreatedAt,
                ImageUrl = entity.ImageUrl,
            };
        }

        public static MealType MapToDTO(MealTypeEntity entity)
        {
            return new MealType
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
