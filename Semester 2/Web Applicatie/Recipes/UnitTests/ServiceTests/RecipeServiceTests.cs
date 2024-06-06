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
    }
}