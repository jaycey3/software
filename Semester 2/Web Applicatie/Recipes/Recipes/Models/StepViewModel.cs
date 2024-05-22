namespace MVC.Models
{
    public class StepViewModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string? Description { get; set; }
        public int RecipeId { get; set; }
    }
}
