using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Energy { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Sugar { get; set; }
        public decimal Fat { get; set; }
        public decimal SaturatedFat { get; set; }
        public decimal Salt { get; set; }
        public decimal Fibers { get; set; }
    }
}