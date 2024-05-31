using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Models
{
    public class RecipeIngredientViewModel
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string? Unit { get; set; }
        public string? Title { get; set; }
    }
}