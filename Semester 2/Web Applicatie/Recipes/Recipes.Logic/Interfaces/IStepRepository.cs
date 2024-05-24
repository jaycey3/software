using Recipes.Logic.Models;

namespace Recipes.Logic.Interfaces
{
    public interface IStepRepository
    {
        StepModel? UpdateStep(int id, int order, string description);
        StepModel? CreateStep(int order, string description, int recipeId);
        void DeleteStep(int id);
    }
}
