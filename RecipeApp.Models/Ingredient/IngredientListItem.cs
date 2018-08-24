using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
   public class IngredientListItem
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => IngredientName;

    }
}
