using Microsoft.AspNetCore.Mvc;
using Recipes.Logic.Services;
using Recipes.Models;
using Ingredient = Recipes.Logic.Models.IngredientModel;

namespace MVC.Controllers
{
    public class IngredientController(IngredientService ingredientService) : Controller
    {
        public ActionResult Index()
        {
            List<Ingredient> ingredients = ingredientService.GetAllIngredients();
            List<IngredientViewModel> ingredientViewModels = [];

            foreach (Ingredient ingredient in ingredients)
            {
                IngredientViewModel ingredientViewModel = ConvertIngredientToIngredientViewModel(ingredient);
                ingredientViewModels.Add(ingredientViewModel);
            }
            return View(ingredientViewModels);
        }

        public ActionResult Details(int id)
        {
            Ingredient? ingredient = ingredientService.GetIngredientById(id);

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

        private static IngredientViewModel ConvertIngredientToIngredientViewModel(Ingredient ingredient)
        {
            IngredientViewModel ingredientViewModel = new()
            {
                Id = ingredient.Id,
                Title = ingredient.Title,
                Energy = ingredient.Energy,
                Protein = ingredient.Protein,
                Carbohydrates = ingredient.Carbohydrates,
                Sugar = ingredient.Sugar,
                Fat = ingredient.Fat,
                SaturatedFat = ingredient.SaturatedFat,
                Salt = ingredient.Salt,
                Fibers = ingredient.Fibers
            };

            return ingredientViewModel;
        }
    }
}
