namespace Recipes.Logic.Models
{
    public class RecipeIngredientModel
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string? Unit {  get; set; }
    }
}
