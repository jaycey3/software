using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;

namespace Recipes.Logic.Services
{
    public class RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository)
    {
        public List<RecipeIngredientModel>? GetAllIngredients(int recipeId)
        {
            List<RecipeIngredientModel>? ingredients = recipeIngredientRepository.GetAllIngredients(recipeId);
            return ingredients;
        }

        public RecipeIngredientModel? UpdateIngredient(int recipeId, int oldIngredientId, int newIngredientId, decimal quantity, string? unit)
        {
            RecipeIngredientModel? ingredient = recipeIngredientRepository.UpdateIngredient(recipeId, oldIngredientId, newIngredientId, quantity, unit);
            return ingredient;
        }

        public RecipeIngredientModel? AddIngredient(int recipeId, int ingredientId, decimal quantity, string? unit)
        {
            RecipeIngredientModel? ingredient = recipeIngredientRepository.AddIngredient(recipeId, ingredientId, quantity, unit);
            return ingredient;
        }

        public string? RemoveIngredient(int recipeId, int ingredientId)
        {
            recipeIngredientRepository.RemoveIngredient(recipeId, ingredientId);
            return null;
        }

        public string? DeleteRecipeIngredients(int recipeId)
        {
            recipeIngredientRepository.DeleteRecipeIngredients(recipeId);
            return null;
        }
    }
}
