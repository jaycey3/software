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

            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
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
                try
                {
                    var newRecipe = recipeService.CreateRecipe(viewModel.Title, viewModel.Description, viewModel.Time, viewModel.Type, viewModel.Img);
                    if (newRecipe != null)
                    {
                        foreach (var step in viewModel.Steps)
                        {
                            step.RecipeId = newRecipe.Id;
                            stepService.CreateStep(step.Order, step.Description, step.RecipeId);
                        }

                        foreach (var ingredient in viewModel.Ingredients)
                        {
                            ingredient.RecipeId = newRecipe.Id;
                            recipeIngredientService.AddIngredient(ingredient.RecipeId, ingredient.IngredientId, ingredient.Quantity, ingredient.Unit);
                        }
                    }

                    TempData["SuccessMessage"] = "Recept succesvol aangemaakt!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Er is een error opgetreden bij het aanmaken van een recept!";
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
                foreach (var step in viewModel.Steps)
                {
                    stepService.UpdateStep(step.Id, step.Order, step.Description);
                }
                foreach (var ingredient in viewModel.Ingredients)
                {
                    recipeIngredientService.UpdateIngredient(viewModel.Id, ingredient.IngredientId, ingredient.Quantity, ingredient.Unit);
                }
                TempData["SuccessMessage"] = "Recept succesvol opgeslagen!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Er is een error opgetreden bij het opslaan van het recept!";
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Recipe? recipe = recipeService.GetRecipeById(id);
            List<Ingredient>? ingredients = ingredientService.GetAllIngredients();

            ViewBag.Ingredients = ingredients;

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
                    stepService.DeleteStepsByRecipeId(viewModel.Id);
                    recipeIngredientService.DeleteRecipeIngredients(viewModel.Id);
                    recipeService.DeleteRecipe(viewModel.Id);
                    TempData["SuccessMessage"] = "Recept succesvol verwijderd!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Er is een error opgetreden tijdens het verwijderen van het recept!";
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
                UserName = recipe.UserName,
                Steps = recipe.Steps,
                Ingredients = recipe.Ingredients
            };

            return recipeViewModel;
        }
    }
}
