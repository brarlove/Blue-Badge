using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class RecipeDetail
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        //public string Directions { get; set; }
        //public string Ingredients { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{RecipeId}] {RecipeName}";
    }
}
