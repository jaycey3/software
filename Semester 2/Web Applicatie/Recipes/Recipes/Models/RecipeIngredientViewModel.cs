using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    public class RecipeIngredientViewModel
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string? Unit { get; set; }
    }
}