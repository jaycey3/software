using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;

namespace Recipes.Logic.Services
{
    public class RecipeService(IRecipeRepository recipeRepository)
    {
        public (List<RecipeModel>?, string?) GetAllRecipes()
        {
            List<RecipeModel>? recipes = recipeRepository.GetAllRecipes();

            if (recipes != null)
            {
                return (recipes, null);
            } else
            {
                return (null, "Er is iets fout gegaan tijdens het ophalen van de recepten.");
            }
        }

        public (RecipeModel?, string?) UpdateRecipe(int id, string title, string description, int time, string type, string img)
        {
            if (title == null || description == null || time == 0 || type == null || img == null)
            {
                return (null, "Niet alle velden zijn correct ingevuld. Probeer het opnieuw.");
            }

            RecipeModel? recipe = recipeRepository.UpdateRecipe(id, title, description, time, type, img);

            if (recipe != null)
            {
                return (recipe, null);
            }
            else
            {
                return (null, "Er is iets fout gegaan bij het bewerken van het recept.");
            }
        }

        public (RecipeModel?, string?) GetRecipeById(int id)
        {
            RecipeModel? recipe = recipeRepository.GetRecipeById(id);
            if (recipe != null)
            {
                return (recipe, null);
            }
            else
            {
                return (null, "Er is iets fout gegaan tijdens het ophalen van het recept.");
            }
        }

        public (RecipeModel?, string?) CreateRecipe(string title, string description, int time, string type, string img)
        {
            if (title == null || description == null || time == 0 || type == null || img == null)
            {
                return (null, "Niet alle velden zijn correct ingevuld. Probeer het opnieuw.");
            }

            RecipeModel? recipe = recipeRepository.CreateRecipe(title, description, time, type, img);

            if (recipe != null)
            {
                return (recipe, null);
            } else
            {
                return (null, "Er is iets fout gegaan bij het aanmaken van het recept.");
            }
        }

        public string? DeleteRecipe(int id)
        {
            try
            {
                recipeRepository.DeleteRecipe(id);
                return null;
            } catch
            {
                return "Er is iets fout gegaan bij het verwijderen van het recept.";
            }
        }
    }
}
