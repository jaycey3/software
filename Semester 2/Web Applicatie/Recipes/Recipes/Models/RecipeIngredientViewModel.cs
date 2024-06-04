using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Models
{
    public class RecipeIngredientViewModel
    {
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public int NewIngredientId { get; set; }
        [Display(Name = "Hoeveelheid")]
        public decimal? Quantity { get; set; }
        public string? Unit { get; set; }
        public string? Title { get; set; }
    }
}