using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class IngredientCreate
    {
        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string IngredientName { get; set; }

        public int RecipeId { get; set; }

        public int Quantity { get; set; }

        public string Directions { get; set; }

        public override string ToString() => IngredientName;

    }
}
