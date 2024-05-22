using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Logic.Models
{
    public class StepModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string? Description { get; set; }
        public int RecipeId { get; set; }
    }
}
