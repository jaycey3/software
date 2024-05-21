using Recipes.Logic.Models;

namespace Recipes.Logic.Interfaces
{
    public interface IRecipeRepository
    {
        List<RecipeModel>? GetAllRecipes();
        RecipeModel? UpdateRecipe(int id, string? title, string? description, int time, string? type, string? img);
        RecipeModel? GetRecipeById(int id);
        RecipeModel? CreateRecipe(string title, string description, int time, string type, string img);
        void DeleteRecipe(int id);
    }
}
