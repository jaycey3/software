using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;

namespace Recipes.Logic.Services
{
    public class StepService(IStepRepository stepRepository)
    {
        public List<StepModel>? GetAllSteps(int recipeId)
        {
            List<StepModel>? method = stepRepository.GetAllSteps(recipeId);
            return method;
        }

        public StepModel? UpdateRecipe(int id, int order, string description)
        {
            StepModel? step = stepRepository.UpdateStep(id, order, description);
            return step;
        }

        public StepModel? CreateStep(int order, string description, int recipeId)
        {
            StepModel? step = stepRepository.CreateStep(order, description, recipeId);
            return step;
        }

        public string? DeleteStep(int id)
        {
            stepRepository.DeleteStep(id);
            return null;
        }
    }
}
