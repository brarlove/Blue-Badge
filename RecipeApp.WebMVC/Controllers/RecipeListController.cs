using RecipeApp.Models;
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
        // GET: RecipeList
        public ActionResult Index()
        {
            var model = new RecipeListListItem[0];
            
            return View(model);
        }
    }
}