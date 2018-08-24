using RecipeApp.Models;
using RecipeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace RecipeApp.WebMVC.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        // GET: Favorite
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteService(userId);
            var model = service.GetFavorites();
            
           return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FavoriteCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var services = new FavoriteService(userId);

            services.CreateFavorite(model);

            return RedirectToAction("Index");
        }
    }
}