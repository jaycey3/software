using Recipes.Logic.Models;

namespace Recipes.Logic.Interfaces
{
    public interface IRecipeRepository
    {
        (List<RecipeModel>?, string?) GetAllRecipes();
        (RecipeModel?, string?) UpdateRecipe(int id, string? title, string? description, int time, string? type, string? img);
        (RecipeModel?, string?) GetRecipeById(int id);
        (RecipeModel?, string?) CreateRecipe(string title, string description, int time, string type, string img);
        (string?, string?) DeleteRecipe(int id);
    }
}
