using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;
        
         public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipe()
                {
                    OwnerId = _userId,
                    RecipeName = model.RecipeName,
                    //Ingredients = model.Ingredients,
                    //Directions = model.Directions,
                    CreatedUtc = DateTimeOffset.Now
                };
            
             using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeId = e.RecipeId,
                                    RecipeName = e.RecipeName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                
                 return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeById(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == recipeId && e.OwnerId == _userId);
                return
                    new RecipeDetail
                    {
                        RecipeId = entity.RecipeId,
                        RecipeName = entity.RecipeName,
                        //Directions = entity.Directions,
                        //Ingredients = entity.Ingredients,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == model.RecipeId && e.OwnerId == _userId);
                
         entity.RecipeName = model.RecipeName;
                //entity.Directions = model.Directions;
                //entity.Ingredients = model.Ingredients;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                
         return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == recipeId && e.OwnerId == _userId);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
