using Recipes.Logic.Models;

namespace Recipes.Logic.Interfaces
{
    public interface IRecipeIngredientRepository
    {
        List<RecipeIngredientModel>? GetAllIngredients(int recipeId);
        RecipeIngredientModel? UpdateIngredient(int recipeId, int oldIngredientId, int newIngredientId, decimal? quantity, string? unit);
        RecipeIngredientModel? AddIngredient(int recipeId, int ingredientId, decimal? quantity, string? unit);
        void RemoveIngredient(int recipeId, int ingredientId);
        void DeleteRecipeIngredients(int recipeId);
    }
}
