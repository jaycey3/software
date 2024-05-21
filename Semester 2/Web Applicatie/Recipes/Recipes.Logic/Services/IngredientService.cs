using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;

namespace Recipes.Logic.Services
{
    public class IngredientService(IIngredientRepository ingredientRepository)
    {
        public List<IngredientModel> GetAllIngredients()
        {
            List<IngredientModel>? ingredients = ingredientRepository.GetAllIngredients();
            return ingredients;
        }

        public IngredientModel UpdateIngredient(int id, string? title, int energy, decimal protein, decimal carbohydrates, decimal sugar, decimal fat, decimal saturatedfat, decimal salt, decimal fibers)
        {
            IngredientModel ingredient = ingredientRepository.UpdateIngredient(id, title, energy, protein, carbohydrates, sugar, fat, saturatedfat, salt, fibers);
            return ingredient;
        }

        public IngredientModel GetIngredientById(int id)
        {
            IngredientModel ingredient = ingredientRepository.GetIngredientById(id);
            return ingredient;
        }

        public IngredientModel CreateIngredient(string? title, int energy, decimal protein, decimal carbohydrates, decimal sugar, decimal fat, decimal saturatedfat, decimal salt, decimal fibers)
        {
            IngredientModel ingredient = ingredientRepository.CreateIngredient(title, energy, protein, carbohydrates, sugar, fat, saturatedfat, salt, fibers);
            return ingredient;
        }

        public string? DeleteIngredient(int id)
        {
            ingredientRepository.DeleteIngredient(id);
            return null;
        }
    }
}
