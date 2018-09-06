using RecipeApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
   public class RecipeListCreate
    {
        [Required]
        [Display(Name = "RecipeName")]
        public int RecipeID { get; set; }
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }
        public virtual Recipe Recipe { get; set; }

        [Required]
        [Display(Name = "IngredientName")]
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public virtual Ingredient Ingredient { get; set; }



    }
}
