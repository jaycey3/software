using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;

namespace Recipes.Logic.Services
{
    public class RecipeService(IRecipeRepository recipeRepository)
    {
        public List<RecipeModel>? GetAllRecipes()
        {
            List<RecipeModel> recipes = recipeRepository.GetAllRecipes();
            return recipes;
        }

        public RecipeModel? UpdateRecipe(int id, string title, string description, int time, string type, string img)
        {
            RecipeModel recipe = recipeRepository.UpdateRecipe(id, title, description, time, type, img);  
            return recipe;
        }

        public RecipeModel? GetRecipeById(int id)
        {
            RecipeModel? recipe = recipeRepository.GetRecipeById(id);
            return recipe;
        }

        public RecipeModel? CreateRecipe(string title, string description, int time, string type, string img)
        {
            RecipeModel? recipe = recipeRepository.CreateRecipe(title, description, time, type, img);
            return recipe;
        }

        public string? DeleteRecipe(int id)
        {
            recipeRepository.DeleteRecipe(id);
            return null;
        }
    }
}
