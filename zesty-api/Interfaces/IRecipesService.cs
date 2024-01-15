using zesty_api.Models;

namespace zesty_api.Interfaces
{
    public interface IRecipesService
    {
        ICollection<Recipe> GetAllRecipes();
        Recipe GetRecipe(int id);
        Recipe CreateRecipe(Recipe recipe);
        Recipe UpdateRecipe(int id, Recipe recipe);
        Recipe DeleteRecipe(int id);

    }
}
