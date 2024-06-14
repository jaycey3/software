using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;

namespace Recipes.Logic.Services
{
    public class RecipeService(IRecipeRepository recipeRepository)
    {
        public (List<RecipeModel>?, string?) GetAllRecipes()
        {
            (List<RecipeModel>? recipes, string? message)  = recipeRepository.GetAllRecipes();

            if (recipes != null)
            {
                if (recipes.Count > 0)
                {
                    return (recipes, null);
                } else
                {
                    return (recipes, message);
                }
            } else
            {
                return (null, message);
            }
        }

        public (RecipeModel?, string?) UpdateRecipe(int id, string? title, string? description, int? time, string? type, string? img)
        {
            if (string.IsNullOrEmpty(title) || description == null || time == 0 || type == null || img == null)
            {
                return (null, "Niet alle velden zijn correct ingevuld. Probeer het opnieuw.");
            }

            (RecipeModel? recipe, string? message) = recipeRepository.UpdateRecipe(id, title, description, time, type, img);

            if (recipe != null)
            {
                return (recipe, message);
            }
            else
            {
                return (null, message);
            }
        }

        public (RecipeModel?, string?) GetRecipeById(int id)
        {
            (RecipeModel? recipe, string? message) = recipeRepository.GetRecipeById(id);
            if (recipe != null)
            {
                return (recipe, null);
            }
            else
            {
                return (null, message);
            }
        }

        public (RecipeModel?, string?) CreateRecipe(string? title, string? description, int? time, string? type, string? img)
        {
            if (title == null || title.Length > 500 || description == null || time == 0 || type == null || img == null)
            {
                return (null, "Niet alle velden zijn correct ingevuld. Probeer het opnieuw.");
            }

            (RecipeModel? recipe, string? message) = recipeRepository.CreateRecipe(title, description, time, type, img);

            if (recipe != null)
            {
                return (recipe, message);
            } else
            {
                return (null, message);
            }
        }

        public (bool?, string?) DeleteRecipe(int id)
        {
            (bool? success, string? message) = recipeRepository.DeleteRecipe(id);

            if (success == true)
            {
                return (true, message);
            } else
            {
                return (false, message);
            }
        }
    }
}
