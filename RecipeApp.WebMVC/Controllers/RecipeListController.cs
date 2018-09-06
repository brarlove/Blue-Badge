using Microsoft.AspNet.Identity;
using RecipeApp.Data;
using RecipeApp.Models;
using RecipeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeApp.WebMVC.Controllers
{
    [Authorize]
    public class RecipeListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecipeList
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeListService(userID);
            var model = service.GetRecipeList();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName");
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "IngredientName");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeListCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeListService(userID);

            //if (service.CreateRecipeList(model))
            //{
            //    return RedirectToAction("Index");
            //}

            return View(model);
        }
    }
}