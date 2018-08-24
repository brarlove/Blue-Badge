using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Data
{
   public class RecipeList
    {
        [Key]
        public int RecipeListId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int Recipeid { get; set; }

        public virtual Recipe Recipe { get; set; }

        [Required]
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
