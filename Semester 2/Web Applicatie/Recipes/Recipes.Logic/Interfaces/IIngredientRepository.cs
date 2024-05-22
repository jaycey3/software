using Recipes.Logic.Models;

namespace Recipes.Logic.Interfaces
{
    public interface IIngredientRepository
    {
        List<IngredientModel>? GetAllIngredients();
        IngredientModel? UpdateIngredient(int id, string? title, string? type);
        IngredientModel? GetIngredientById(int id);
        IngredientModel? CreateIngredient(string? title, string? type);
        void DeleteIngredient(int id);
    }
}