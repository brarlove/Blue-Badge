using RecipeApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
   public class RecipeListListItem
    {
        [Display(Name ="RecipeListId")]
        public int RecipeListId { get; set; }

        public int RecipeId { get; set; }

        [Display(Name = "Recipe")]
        public string Recipe { get; set; }


        public int IngredientId { get; set; }


        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
