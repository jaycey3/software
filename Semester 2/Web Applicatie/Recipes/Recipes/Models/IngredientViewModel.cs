using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Titel")]
        public string? Title { get; set; }
        [Display(Name = "Energie (kcal)")]
        public int Energy { get; set; }
        [Display(Name = "Eiwit")]
        public decimal Protein { get; set; }
        [Display(Name = "Koolhydraten")]
        public decimal Carbohydrates { get; set; }
        [Display(Name = "Waarvan suikers")]
        public decimal Sugar { get; set; }
        [Display(Name = "Vet")]
        public decimal Fat { get; set; }
        [Display(Name = "Waarvan verzadigd")]
        public decimal SaturatedFat { get; set; }
        [Display(Name = "Zout")]
        public decimal Salt { get; set; }
        [Display(Name = "Voedingsvezels")]
        public decimal Fibers { get; set; }
    }
}