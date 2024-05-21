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
            List<Ingredient>? ingredients = ingredientService.GetAllIngredients();
            List<IngredientViewModel> ingredientViewModels = [];

            if (ingredients != null)
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    IngredientViewModel ingredientViewModel = ConvertIngredientToIngredientViewModel(ingredient);
                    ingredientViewModels.Add(ingredientViewModel);
                }
            }
            return View(ingredientViewModels);
        }

        public ActionResult Details(int id)
        {
            Ingredient ingredient = ingredientService.GetIngredientById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            IngredientViewModel ingredientViewModel = ConvertIngredientToIngredientViewModel(ingredient);

            return View(ingredientViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ingredientService.CreateIngredient(viewModel.Title, viewModel.Energy, viewModel.Protein, viewModel.Carbohydrates, viewModel.Sugar, viewModel.Fat, viewModel.SaturatedFat, viewModel.Salt, viewModel.Fibers);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error while trying to create ingredient: " + ex);
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(IngredientViewModel viewModel)
        {
            Ingredient ingredient = ingredientService.UpdateIngredient(viewModel.Id, viewModel.Title, viewModel.Energy, viewModel.Protein, viewModel.Carbohydrates, viewModel.Sugar, viewModel.Fat, viewModel.SaturatedFat, viewModel.Salt, viewModel.Fibers);

            if (ingredient != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine("There was an error while trying to update ingredient");
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Ingredient ingredient = ingredientService.GetIngredientById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            IngredientViewModel ingredientViewModel = ConvertIngredientToIngredientViewModel(ingredient);

            return View(ingredientViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Ingredient ingredient = ingredientService.GetIngredientById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            IngredientViewModel ingredientViewModel = ConvertIngredientToIngredientViewModel(ingredient);

            return View(ingredientViewModel); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(IngredientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ingredientService.DeleteIngredient(viewModel.Id);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error while trying to delete ingredient: " + ex);
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
