namespace Recipes.Logic.Models
{
    public class RecipeIngredientModel
    {
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public int NewIngredientId { get; set; }
        public decimal? Quantity { get; set; }
        public string? Unit {  get; set; }
        public string? Title { get; set; }
    }
}
