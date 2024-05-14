using Recipes.DAL.Repository;
using Recipes.Logic.Models;
using Recipes.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Logic.Services
{
    public class RecipeService
    {
        private readonly RecipeRepository _recipeRepository;

        public RecipeService()
        {
            _recipeRepository = new();
        }

        public List<RecipeModel> GetAllRecipes()
        {
            var recipeDTOs = _recipeRepository.GetAllRecipes();

            var recipes = new List<RecipeModel>();
            foreach (var recipeDTO in recipeDTOs)
            {
                var recipe = new RecipeModel
                {
                    Id = recipeDTO.Id,
                    Title = recipeDTO.Title,
                    Description = recipeDTO.Description,
                    Time = recipeDTO.Time,
                    Type = recipeDTO.Type,
                    Img = recipeDTO.Img,
                    UserId = recipeDTO.UserId,
                };
                recipes.Add(recipe);
            }
            return recipes;
        }

        public RecipeModel? UpdateRecipe(int id, string title, string description, int time, string type, string img)
        {
            RecipeDTO recipeDTO = _recipeRepository.UpdateRecipe(id, title, description, time, type, img);

            if (recipeDTO != null)
            {
                var recipe = new RecipeModel
                {
                    Id = recipeDTO.Id,
                    Title = recipeDTO.Title,
                    Description = recipeDTO.Description,
                    Time = recipeDTO.Time,
                    Type = recipeDTO.Type,
                    Img = recipeDTO.Img,
                };

                return recipe;
            }
            else
            {
                return null;
            }
        }

        public RecipeRepository Get_recipeRepository()
        {
            return _recipeRepository;
        }

        public static RecipeModel GetRecipeById(int id, RecipeRepository _recipeRepository)
        {
            RecipeDTO recipeDTO = _recipeRepository.GetRecipeById(id);
            var recipe = new RecipeModel
            {
                Id = recipeDTO.Id,
                Title = recipeDTO.Title,
                Description = recipeDTO.Description,
                Time = recipeDTO.Time,
                Type = recipeDTO.Type,
                Img = recipeDTO.Img,
                UserId = recipeDTO.UserId
            };

            return recipe;
        }

        public RecipeModel? CreateRecipe(string title, string description, int time, string type, string img)
        {
            RecipeDTO recipeDTO = _recipeRepository.CreateRecipe(title, description, time, type, img);

            if (recipeDTO != null)
            {
                var recipe = new RecipeModel
                {
                    Title = recipeDTO.Title,
                    Description = recipeDTO.Description,
                    Time = recipeDTO.Time,
                    Type = recipeDTO.Type,
                    Img = recipeDTO.Img,
                };

                return recipe;
            }
            else
            {
                return null;
            }
        }
    }
}
