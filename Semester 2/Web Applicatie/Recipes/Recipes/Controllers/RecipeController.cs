using Microsoft.AspNetCore.Mvc;
using Recipes.Logic.Services;
using Recipes.Models;
using Recipe = Recipes.Logic.Models.RecipeModel;

namespace Recipes.Controllers
{
    public class RecipeController(RecipeService recipeService) : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Recipe>? recipes = recipeService.GetAllRecipes();
            List<RecipeViewModel> recipeViewModels = [];

            if (recipes != null)
            {
                foreach (Recipe recipe in recipes)
                {
                    RecipeViewModel recipeViewModel = ConvertRecipeToRecipeViewModel(recipe);
                    recipeViewModels.Add(recipeViewModel);
                }
            }
            return View(recipeViewModels);
        }

        public ActionResult Details(int id)
        {
            Recipe? recipe = recipeService.GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            RecipeViewModel recipeViewModel = ConvertRecipeToRecipeViewModel(recipe);

            return View(recipeViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    recipeService.CreateRecipe(viewModel.Title, viewModel.Description, viewModel.Time, viewModel.Type, viewModel.Img);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error while trying to create recipe: " + ex);
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(RecipeViewModel viewModel)
        {
            Recipe? recipe = recipeService.UpdateRecipe(viewModel.Id, viewModel.Title, viewModel.Description, viewModel.Time, viewModel.Type, viewModel.Img);

            if (recipe != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine("There was an error while trying to update recipe");
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Recipe? recipe = recipeService.GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            RecipeViewModel recipeViewModel = ConvertRecipeToRecipeViewModel(recipe);

            return View(recipeViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Recipe? recipe = recipeService.GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            RecipeViewModel recipeViewModel = ConvertRecipeToRecipeViewModel(recipe);

            return View(recipeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RecipeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    recipeService.DeleteRecipe(viewModel.Id);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error while trying to delete recipe: " + ex);
                }
            }
            return View(viewModel);
        }

        private static RecipeViewModel ConvertRecipeToRecipeViewModel(Recipe recipe)
        {
            RecipeViewModel recipeViewModel = new()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Time = recipe.Time,
                Type = recipe.Type,
                Img = recipe.Img,
                UserId = recipe.UserId,
                UserName = recipe.UserName
            };

            return recipeViewModel;
        }
    }
}
