using zesty_api.Models;

namespace zesty_api.Interfaces
{
    public interface IRecipesService
    {
        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipe(int recipeId);
        Recipe CreateRecipe(Recipe recipe);
        Task UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(int recipeId);

    }
}
