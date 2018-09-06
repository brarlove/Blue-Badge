using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
   public class IngredientService
    {
        private readonly Guid _userId;

        public IngredientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateIngredient(IngredientCreate model)
        {
            var ingredient =
                new Ingredient()
                {
                    OwnerId = _userId,
                    RecipeId= model.RecipeId,
                    IngredientName = model.IngredientName,
                    Directions = model.Directions,
                    Quantity = model.Quantity,
                    CreatedUtc = DateTimeOffset.Now
                };
            
             using (var ctx = new ApplicationDbContext())
            {
               var addedIngredient = ctx.Ingredients.Add(ingredient);
                ctx.SaveChanges();
                RecipeListService Rls = new RecipeListService(_userId);
                RecipeListCreate Rlc = new RecipeListCreate
                {
                    RecipeID = model.RecipeId,
                    IngredientID = addedIngredient.IngredientId                    
                };
                
                return Rls.CreateRecipeList(Rlc);
            }

        }

        public IEnumerable<IngredientListItem> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientId = e.IngredientId,
                                    IngredientName = e.IngredientName,
                                    Directions = e.Directions,
                                    Quantity = e.Quantity,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                
                 return query.ToArray();
            }
        }

        public IngredientDetail GetIngredientById(int ingredientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientId == ingredientId && e.OwnerId == _userId);
                return
                    new IngredientDetail
                    {
                        IngredientId = entity.IngredientId,
                        IngredientName = entity.IngredientName,
                        Quantity = entity.Quantity,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateIngredient(IngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientId == model.IngredientId && e.OwnerId == _userId);

                entity.IngredientName = model.IngredientName;
                entity.Quantity = model.Quantity;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIngredient(int ingredientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientId == ingredientId && e.OwnerId == _userId);

                ctx.Ingredients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
