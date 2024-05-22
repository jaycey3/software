using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;

namespace Recipes.Logic.Services
{
    public class IngredientService(IIngredientRepository ingredientRepository)
    {
        public List<IngredientModel>? GetAllIngredients()
        {
            List<IngredientModel>? ingredients = ingredientRepository.GetAllIngredients();
            return ingredients;
        }

        public IngredientModel? UpdateIngredient(int id, string? title, string? type)
        {
            IngredientModel? ingredient = ingredientRepository.UpdateIngredient(id, title, type);
            return ingredient;
        }

        public IngredientModel? GetIngredientById(int id)
        {
            IngredientModel? ingredient = ingredientRepository.GetIngredientById(id);
            return ingredient;
        }

        public IngredientModel? CreateIngredient(string? title, string? type)
        {
            IngredientModel? ingredient = ingredientRepository.CreateIngredient(title, type);
            return ingredient;
        }

        public string? DeleteIngredient(int id)
        {
            ingredientRepository.DeleteIngredient(id);
            return null;
        }
    }
}
