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
            try
            {
                //db.Recipes.Add();
                db.SaveChanges();
                return recipe;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Recipe DeleteRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Recipe> GetAllRecipes()
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public Recipe UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }


        public static Recipe MapToDTO(RecipeEntity entity)
        {
            return new Recipe
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Title = entity.Title,
                Description = entity.Description,
                Ingredients = entity.Ingredients,
                Instructions = entity.Instructions,
                CreatedAt = entity.CreatedAt,
                ImageUrl = entity.ImageUrl,
                //Comments = entity.Comments.Select(CommentsService.MapToDTO).ToList()
            };
        }
    }
}
