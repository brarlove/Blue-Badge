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
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            var model = service.GetIngredients();

            return View(model);
        }

        public ActionResult Create(int id)
        {
            var model =
               new IngredientCreate
               {
                   RecipeId = id,
                   IngredientName = "",
               };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientCreate model)
        {

            if (!ModelState.IsValid) return View(model);            
            
         var service = CreateIngredientService();
            
         if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "Your ingredient was created.";
                return RedirectToAction("Index","RecipeList",null);
            };
            
         ModelState.AddModelError("", "Ingredient could not be created.");
            
         return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIngredientService();
            var detail = service.GetIngredientById(id);
            var model =
                new IngredientEdit
                {
                    IngredientId = detail.IngredientId,
                    IngredientName = detail.IngredientName,
                    Quantity = detail.Quantity
                };
                  return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IngredientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIngredientService();
            
            if (service.UpdateIngredient(model))
            {
                TempData["SaveResult"] = "Your ingredient was updated.";
                return RedirectToAction("Index");
            }
            
            ModelState.AddModelError("", "Your ingredient could not be updated.");

            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateIngredientService();

            service.DeleteIngredient(id);

            TempData["SaveResult"] = "Your Ingredient was deleted";

            return RedirectToAction("Index");
        }


        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            return service;
        }
    }
}