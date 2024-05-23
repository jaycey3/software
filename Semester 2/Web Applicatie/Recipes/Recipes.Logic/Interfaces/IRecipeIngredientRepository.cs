using Recipes.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Logic.Interfaces
{
    public interface IRecipeIngredientRepository
    {
        List<RecipeIngredientModel>? GetAllIngredients(int recipeId);
        RecipeIngredientModel? UpdateIngredient(int recipeId, int ingredientId, decimal quantity, string? unit);
        RecipeIngredientModel? AddIngredient(int recipeId, int ingredientId, decimal quantity, string? unit);
        void RemoveIngredient(int recipeId, int ingredientId);
    }
}
