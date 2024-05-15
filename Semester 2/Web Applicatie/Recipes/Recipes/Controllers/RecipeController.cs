using Microsoft.AspNetCore.Mvc;
using Recipes.Logic.Models;
using Recipes.Logic.Services;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeService _recipeService;

        public RecipeController ()
        {
            _recipeService = new();
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<RecipeModel> recipes = _recipeService.GetAllRecipes();
            List<RecipeViewModel> recipeViewModels = [];

            foreach (RecipeModel recipe in recipes)
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
                };
                recipeViewModels.Add(recipeViewModel);
            }
            return View(recipeViewModels);
        }

        public ActionResult Details(int id)
        {
            var recipe = RecipeService.GetRecipeById(id, _recipeService.Get_recipeRepository());

            if (recipe == null)
            {
                return NotFound();
            }

            var recipeViewModel = new RecipeViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Time = recipe.Time,
                Type = recipe.Type,
                Img = recipe.Img,
                UserId = recipe.UserId
            };

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
                    _recipeService.CreateRecipe(viewModel.Title, viewModel.Description, viewModel.Time, viewModel.Type, viewModel.Img);
                    TempData["SuccessMessage"] = "Recipe created successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error while trying to create recipe: " + ex);
                    TempData["ErrorMessage"] = "An error occurred while creating the recipe. Please try again.";
                }
            }
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(RecipeViewModel viewModel)
        {
            RecipeModel recipe = _recipeService.UpdateRecipe(viewModel.Id, viewModel.Title, viewModel.Description, viewModel.Time, viewModel.Type, viewModel.Img);

            if (recipe != null)
            {
                TempData["SuccessMessage"] = "The recipe was updated succesfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error while trying to update the recipe.";
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var recipe = RecipeService.GetRecipeById(id, _recipeService.Get_recipeRepository());

            if (recipe == null)
            {
                return NotFound();
            }

            var recipeViewModel = new RecipeViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Time = recipe.Time,
                Type = recipe.Type,
                Img = recipe.Img,
                UserId = recipe.UserId
            };

            return View(recipeViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var recipe = RecipeService.GetRecipeById(id, _recipeService.Get_recipeRepository());

            if (recipe == null)
            {
                return NotFound();
            }

            var recipeViewModel = new RecipeViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Time = recipe.Time,
                Type = recipe.Type,
                Img = recipe.Img,
                UserId = recipe.UserId
            };

            return View(recipeViewModel); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RecipeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _recipeService.DeleteRecipe(viewModel.Id);
                    TempData["SuccessMessage"] = "Recipe deleted successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error while trying to delete recipe: " + ex);
                    TempData["ErrorMessage"] = "An error occurred while deleting the recipe. Please try again.";
                }
            }
            return View(viewModel);
        }
    }
}
