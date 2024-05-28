using Recipes.Logic.Models;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Recept")]
        public string? Title { get; set; }
        [Display(Name = "Beschrijving")]
        public string? Description { get; set; }
        [Display(Name = "Bereidingstijd")]
        public int Time { get; set; }
        [Display(Name = "Menugang")]
        public string? Type { get; set; }
        [Display(Name = "Afbeelding")]
        public string? Img { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Gebruiker")]
        public string? UserName { get; set; }
        public List<StepModel>? Steps { get; set; }
        public List<RecipeIngredientModel>? Ingredients { get; set; }
    }
}
