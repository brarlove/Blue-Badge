using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
   public class FavoriteService
    {
        private readonly Guid _userId;
        
         public FavoriteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFavorite(FavoriteCreate model)
        {
            var entity =
                new Favorite()
                {
                    OwnerId = _userId,
                    RecipeName = model.RecipeName,
                    Directions = model.Directions,
                    Ingredients = model.Ingredients,
                    Origin = model.Origin,
                    CreatedUtc = DateTimeOffset.Now
                };
            
             using (var ctx = new ApplicationDbContext())
            {
                ctx.Favorites.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FavoriteListItem> GetFavorites()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Favorites
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FavoriteListItem
                                {
                                    FavoriteId = e.FavoriteId,
                                    RecipeName = e.RecipeName,
                                    Origin = e.Origin,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                
                 return query.ToArray();
            }
        }
    }
}
