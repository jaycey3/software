using Microsoft.AspNetCore.Mvc;
using Recipes.Logic.Services;
using Recipes.Models;
using Recipe = Recipes.Logic.Models.RecipeModel;
using Ingredient = Recipes.Logic.Models.IngredientModel;

namespace Recipes.Controllers
{
    public class RecipeController(RecipeService recipeService,
        StepService stepService,
        IngredientService ingredientService,
        RecipeIngredientService recipeIngredientService) : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            (List<Recipe>? recipes, string? message) = recipeService.GetAllRecipes();
            List<RecipeViewModel> recipeViewModels = [];

            if (recipes != null)
            {

                foreach (Recipe recipe in recipes)
                {
                    RecipeViewModel recipeViewModel = ConvertRecipeToRecipeViewModel(recipe);
                    recipeViewModels.Add(recipeViewModel);
                }
            }
            else
            {
                TempData["ErrorMessage"] = message;
            }


            //ViewBag messages voor Index view
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            if (TempData["InfoMessage"] != null)
            {
                ViewBag.InfoMessage = TempData["InfoMessage"];
            }

            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }

            return View(recipeViewModels);
        }

        public ActionResult Details(int id)
        {
            (Recipe? recipe, string? errorMessage) = recipeService.GetRecipeById(id);

            if (recipe == null)
            {
                TempData["ErrorMessage"] = errorMessage;
                return RedirectToAction("Index");
            }

            RecipeViewModel recipeViewModel = ConvertRecipeToRecipeViewModel(recipe);

            return View(recipeViewModel);
        }

        public ActionResult Create()
        {
            List<Ingredient>? ingredients = ingredientService.GetAllIngredients();
            ViewBag.Ingredients = ingredients;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                (Recipe? recipe, string? message) = recipeService.CreateRecipe(viewModel.Title, viewModel.Description, viewModel.Time, viewModel.Type, viewModel.Img);

                if (recipe == null)
                {
                    ViewBag.ErrorMessage = message;

                    List<Ingredient>? ingredients = ingredientService.GetAllIngredients();
                    ViewBag.Ingredients = ingredients;

                    return View(viewModel);
                }

                try
                {
                    if (recipe != null)
                    {
                        foreach (var step in viewModel.Steps)
                        {
                            step.RecipeId = recipe.Id;
                            stepService.CreateStep(step.Order, step.Description, step.RecipeId);
                        }

                        foreach (var ingredient in viewModel.Ingredients)
                        {
                            ingredient.RecipeId = recipe.Id;
                            recipeIngredientService.AddIngredient(ingredient.RecipeId, ingredient.IngredientId, ingredient.Quantity, ingredient.Unit);
                        }
                    }

                    TempData["SuccessMessage"] = message;
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["ErrorMessage"] = message;
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(RecipeViewModel viewModel)
        {
            (Recipe? recipe, string? message) = recipeService.UpdateRecipe(viewModel.Id, viewModel.Title, viewModel.Description, viewModel.Time, viewModel.Type, viewModel.Img);

            try
            {
                if (recipe != null)
                {
                    foreach (var step in viewModel.Steps)
                    {
                        stepService.UpdateStep(step.Id, step.Order, step.Description);
                    }
                    foreach (var ingredient in viewModel.Ingredients)
                    {
                        recipeIngredientService.UpdateIngredient(viewModel.Id, ingredient.IngredientId, ingredient.NewIngredientId, ingredient.Quantity, ingredient.Unit);
                    }
                }

                TempData["SuccessMessage"] = message;
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorMessage"] = message;
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            (Recipe? recipe, string? errorMessage) = recipeService.GetRecipeById(id);
            RecipeViewModel recipeViewModel = ConvertRecipeToRecipeViewModel(recipe);

            if (recipe != null)
            {
                List<Ingredient>? ingredients = ingredientService.GetAllIngredients();
                ViewBag.Ingredients = ingredients;
                return View(recipeViewModel);
            }
            else
            {
                TempData["ErrorMessage"] = errorMessage;
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            (Recipe? recipe, string? errorMessage) = recipeService.GetRecipeById(id);

            if (recipe != null)
            {
                RecipeViewModel recipeViewModel = ConvertRecipeToRecipeViewModel(recipe);
                return View(recipeViewModel);
            }
            else
            {
                TempData["ErrorMessage"] = errorMessage;
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RecipeViewModel viewModel)
        {
            string? errorMessage = null;

            try
            {
                stepService.DeleteStepsByRecipeId(viewModel.Id);
                recipeIngredientService.DeleteRecipeIngredients(viewModel.Id);

                (bool? success, string? message) = recipeService.DeleteRecipe(viewModel.Id);

                if (success == true)
                {
                    TempData["SuccessMessage"] = message;
                    return RedirectToAction("Index");
                }
                else
                {
                    errorMessage = message;
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["ErrorMessage"] = errorMessage;
                return RedirectToAction("Index");
            }
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
                UserName = recipe.UserName,
                Steps = recipe.Steps,
                Ingredients = recipe.Ingredients
            };

            return recipeViewModel;
        }
    }
}
