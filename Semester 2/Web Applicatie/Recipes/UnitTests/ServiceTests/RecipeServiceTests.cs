using Moq;
using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;
using Recipes.Logic.Services;

namespace UnitTests.ServiceTests
{
    [TestClass]
    public class RecipeServiceTests
    {
        private Mock<IRecipeRepository> mockRecipeRepository;
        private RecipeService recipeService;

        [TestInitialize]
        public void Setup()
        {
            mockRecipeRepository = new Mock<IRecipeRepository>();
            recipeService = new RecipeService(mockRecipeRepository.Object);
        }

        [TestMethod]
        public void GetAllRecipesError()
        {
            (RecipeModel? recipe, string? message) = recipeService.CreateRecipe(null, "Description", 30, "Type", "Img");

            Assert.IsNull(recipe);
            Assert.AreEqual("Niet alle velden zijn correct ingevuld. Probeer het opnieuw.", message);
        }

        [TestMethod]
        public void CreateRecipeNullTitle()
        {
            (RecipeModel? recipe, string? message) = recipeService.CreateRecipe(null, "Description", 30, "Type", "Img");

            Assert.IsNull(recipe);
            Assert.AreEqual("Niet alle velden zijn correct ingevuld. Probeer het opnieuw.", message);
        }

        [TestMethod]
        public void CreateRecipeZeroTime()
        {
            (RecipeModel? recipe, string? message) = recipeService.CreateRecipe("Title", "Description", 0, "Type", "Img");

            Assert.IsNull(recipe);
            Assert.AreEqual("Niet alle velden zijn correct ingevuld. Probeer het opnieuw.", message);
        }

        [TestMethod]
        public void CreateRecipeSuccessfully()
        {
            RecipeModel recipeModel = new() { Id = 1, Title = "Title", Description = "Description", Time = 30, Type = "Type", Img = "Img" };

            mockRecipeRepository.Setup(repository => repository.CreateRecipe(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                                .Returns((recipeModel, "Recept succesvol opgeslagen!"));

            (RecipeModel? recipe, string? message) = recipeService.CreateRecipe("Title", "Description", 30, "Type", "Img");

            Assert.IsNotNull(recipe);
            Assert.AreEqual("Recept succesvol opgeslagen!", message);
        }

        [TestMethod]
        public void CreateRecipeRepositoryError()
        {
            mockRecipeRepository.Setup(repository => repository.CreateRecipe(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                                .Returns((null, "Er is iets fout gegaan bij het opslaan van het recept."));

            (RecipeModel? recipe, string? message) = recipeService.CreateRecipe("Title", "Description", 30, "Type", "Img");

            Assert.IsNull(recipe);
            Assert.AreEqual("Er is iets fout gegaan bij het opslaan van het recept.", message);
        }

        [TestMethod]
        public void GetAllRecipesNoRecipes()
        {
            List<RecipeModel> recipesList = [];

            mockRecipeRepository.Setup(repository => repository.GetAllRecipes())
                .Returns((recipesList, "Geen recepten gevonden."));

            (List<RecipeModel>? recipes, string? message) = recipeService.GetAllRecipes();

            Assert.IsNotNull(recipes);
            Assert.AreEqual("Geen recepten gevonden.", message);
        }

        [TestMethod]
        public void GetAllRecipesSuccess()
        {
            List<RecipeModel> recipesList = [];
            RecipeModel recipeModel = new() { Id = 1, Title = "Title", Description = "Description", Time = 30, Type = "Type", Img = "Img" };
            recipesList.Add(recipeModel);

            mockRecipeRepository.Setup(repository => repository.GetAllRecipes())
                .Returns((recipesList, null));

            (List<RecipeModel>? recipes, string? message) = recipeService.GetAllRecipes();

            Assert.IsNotNull (recipes);
            Assert.AreEqual(recipes, recipesList);
            Assert.AreEqual(null, message);
        }

        [TestMethod]
        public void GetAllrecipesRepositoryError()
        {
            mockRecipeRepository.Setup(repository => repository.GetAllRecipes())
                .Returns((null, "Er is iets fout gegaan tijdens het ophalen van de recepten."));

            (List<RecipeModel>? recipes, string? message) = recipeService.GetAllRecipes();

            Assert.IsNull(recipes);
            Assert.AreEqual("Er is iets fout gegaan tijdens het ophalen van de recepten.", message);
        }

        [TestMethod]
        public void UpdateRecipeNullTitle()
        {
            (RecipeModel? recipe, string? message) = recipeService.UpdateRecipe(1, null, "Description", 30, "Type", "Img");

            Assert.IsNull(recipe);
            Assert.AreEqual("Niet alle velden zijn correct ingevuld. Probeer het opnieuw.", message);
        }

        [TestMethod]
        public void UpdateRecipeZeroTime()
        {
            (RecipeModel? recipe, string? message) = recipeService.UpdateRecipe(1, "Title", "Description", 0, "Type", "Img");

            Assert.IsNull(recipe);
            Assert.AreEqual("Niet alle velden zijn correct ingevuld. Probeer het opnieuw.", message);
        }

        [TestMethod]
        public void UpdateRecipeSuccessfully()
        {
            RecipeModel recipeModel = new() { Id = 1, Title = "Title", Description = "Description", Time = 30, Type = "Type", Img = "Img" };

            mockRecipeRepository.Setup(repository => repository.UpdateRecipe(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                                .Returns((recipeModel, "Recept succesvol bijgewerkt!"));

            (RecipeModel? recipe, string? message) = recipeService.UpdateRecipe(1, "Title", "Description", 30, "Type", "Img");

            Assert.IsNotNull(recipe);
            Assert.AreEqual("Recept succesvol bijgewerkt!", message);
        }

        [TestMethod]
        public void UpdateRecipeRepositoryError()
        {
            mockRecipeRepository.Setup(repository => repository.UpdateRecipe(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                                .Returns((null, "Er is iets fout gegaan bij het bewerken van het recept."));

            (RecipeModel? recipe, string? message) = recipeService.UpdateRecipe(1, "Title", "Description", 30, "Type", "Img");

            Assert.IsNull(recipe);
            Assert.AreEqual("Er is iets fout gegaan bij het bewerken van het recept.", message);
        }

        [TestMethod]
        public void GetRecipeByIdDoesNotExist()
        {
            mockRecipeRepository.Setup(repository => repository.GetRecipeById(It.IsAny<int>()))
                .Returns((null, "Recept niet gevonden."));

            (RecipeModel? recipe, string? message) = recipeService.GetRecipeById(1);

            Assert.IsNull(recipe);
            Assert.AreEqual("Recept niet gevonden.", message);
        }

        [TestMethod]
        public void GetRecipeByIdSuccess()
        {
            RecipeModel recipeModel = new() { Id = 1, Title = "Title", Description = "Description", Time = 30, Type = "Type", Img = "Img" };

            mockRecipeRepository.Setup(repository => repository.GetRecipeById(It.IsAny<int>()))
                .Returns((recipeModel, null));

            (RecipeModel? recipe, string? message) = recipeService.GetRecipeById(1);

            Assert.IsNotNull(recipe);
            Assert.AreEqual(null, message);
        }

        [TestMethod]
        public void GetRecipeByIdRepositoryError()
        {
            mockRecipeRepository.Setup(repository => repository.GetRecipeById(It.IsAny<int>()))
                .Returns((null, "Er is iets fout gegaan bij het ophalen van het recept."));

            (RecipeModel? recipe, string? message) = recipeService.GetRecipeById(1);

            Assert.IsNull(recipe);
            Assert.AreEqual("Er is iets fout gegaan bij het ophalen van het recept.", message);
        }

        [TestMethod]
        public void DeleteRecipeSuccess()
        {
            mockRecipeRepository.Setup(repository => repository.DeleteRecipe(It.IsAny<int>()))
                .Returns((true, "Recept succesvol verwijderd!"));

            (bool? success, string? message) = recipeService.DeleteRecipe(1);

            Assert.IsTrue(success);
            Assert.AreEqual("Recept succesvol verwijderd!", message);
        }

        [TestMethod]
        public void DeleteRecipeRepistoryError()
        {
            mockRecipeRepository.Setup(repository => repository.DeleteRecipe(It.IsAny<int>()))
                .Returns((false, "Er is iets fout gegaan bij het verwijderen van het recept."));

            (bool? success, string? message) = recipeService.DeleteRecipe(1);

            Assert.IsFalse(success);
            Assert.AreEqual("Er is iets fout gegaan bij het verwijderen van het recept.", message);
        }
    }
}