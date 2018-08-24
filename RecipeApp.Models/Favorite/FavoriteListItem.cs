using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class FavoriteListItem
    {
        public int FavoriteId { get; set; }
        public string RecipeName { get; set; }
        public string Origin { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => RecipeName;


    }
}
