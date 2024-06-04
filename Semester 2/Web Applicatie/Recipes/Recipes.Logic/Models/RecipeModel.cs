namespace Recipes.Logic.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Time { get; set; }
        public string? Type { get; set; }
        public string? Img { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public List<StepModel>? Steps { get; set; }
        public List<RecipeIngredientModel>? Ingredients { get; set; }
    }
}
