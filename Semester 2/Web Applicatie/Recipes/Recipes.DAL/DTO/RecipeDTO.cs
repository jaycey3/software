using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.DAL.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Time {  get; set; }
        public string? Type { get; set; }
        public string? Img { get; set; }
        public int UserId { get; set; }
    }
}
