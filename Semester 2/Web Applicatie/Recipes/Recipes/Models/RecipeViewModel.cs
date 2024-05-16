using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Bereidingstijd")]
        public int Time { get; set; }
        [Display(Name = "Menugang")]
        public string? Type { get; set; }
        [Display(Name = "Afbeelding")]
        public string? Img { get; set; }
        public int UserId { get; set; }
    }
}
