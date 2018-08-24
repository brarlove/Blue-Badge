using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
   public class IngredientEdit
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
    }
}
