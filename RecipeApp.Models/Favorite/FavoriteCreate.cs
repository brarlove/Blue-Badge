using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
   public class FavoriteCreate
    {
        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string RecipeName { get; set; }

        [MaxLength(8000)]
        public string Directions { get; set; }

        [MaxLength(50)]
        public string Origin { get; set; }

        [MaxLength(8000)]
        public string Ingredients { get; set; }

        public override string ToString() => RecipeName;

    }
}
