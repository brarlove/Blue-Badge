using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class RecipeListService
    {
        private readonly Guid _userId;
        
        public RecipeListService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipeList(RecipeListCreate model)
        {
            var entity =
                new RecipeList()
                {
                    OwnerId = _userId,
                    Recipeid = model.RecipeID,
                    IngredientId = model.IngredientID,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RecipeList.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListListItem> GetRecipeList()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        .RecipeList
                        .Where(e => e.OwnerId == _userId)
                        .Include(e => e.Recipe).Include(e => e.Ingredient)
                        .Select(
                            e =>
                                new RecipeListListItem
                                {
                                    RecipeListId = e.RecipeListId,
                                    RecipeId = e.Recipeid,
                                    Recipe = e.Recipe.RecipeName,
                                    Ingredient = e.Ingredient.IngredientName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                
                 return query.ToArray();
            }
        }


        public IEnumerable<IngredientListItem> GetIngredientsForRecipe(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RecipeList
                    .Where(e => e.OwnerId == _userId && e.Recipeid == id)
                    .Select(
                        e => new IngredientListItem
                        {
                            IngredientId = e.IngredientId,
                            IngredientName = e.Ingredient.IngredientName,
                            Quantity = e.Ingredient.Quantity
                        });
                return query.ToArray();
            }
        }
    }
}
  
