using Recipes.Logic.Models;

namespace Recipes.Logic.Interfaces
{
    public interface IIngredientRepository
    {
        List<IngredientModel>? GetAllIngredients();
        IngredientModel? UpdateIngredient(int id, string? title, int energy, decimal protein, decimal carbohydrates, decimal sugar, decimal fat, decimal saturatedfat, decimal salt, decimal fibers);
        IngredientModel? GetIngredientById(int id);
        IngredientModel? CreateIngredient(string? title, int energy, decimal protein, decimal carbohydrates, decimal sugar, decimal fat, decimal saturatedfat, decimal salt, decimal fibers);
        void DeleteIngredient(int id);
    }
}
