using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public string Directions { get; set; }
        [Required]
        public string Ingredients { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
