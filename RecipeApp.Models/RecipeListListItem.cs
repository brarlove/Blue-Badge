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
        public int RecipeListId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
