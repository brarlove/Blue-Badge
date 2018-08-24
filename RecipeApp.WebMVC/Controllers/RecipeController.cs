using Microsoft.AspNet.Identity;
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
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            var model = service.GetRecipes();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRecipeService();

            if (service.CreateRecipe(model))
            {
                ViewBag.SaveResult = "Your recipe was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Recipe could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);
            var model =
                new RecipeEdit
                {
                    RecipeId = detail.RecipeId,
                    RecipeName = detail.RecipeName,
                    Directions = detail.Directions,
                    Ingredients = detail.Ingredients
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RecipeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.UpdateRecipe(model))
            {
                TempData["SaveResult"] = "Your recipe was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your recipe could not be updated.");
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipe(int id)
        {
            var service = CreateRecipeService();

            service.DeleteRecipe(id);

            TempData["SaveResult"] = "Your Recipe was deleted";

            return RedirectToAction("Index");
        }

        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }
    }
}