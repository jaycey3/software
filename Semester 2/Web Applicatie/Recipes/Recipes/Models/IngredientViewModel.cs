using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Product")]
        public string? Title { get; set; }
        public string? Type { get; set; }
    }
}