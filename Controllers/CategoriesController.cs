using Felipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Felipe.Controllers
{
    public class CategoriesController : Controller
    {
        private static IList<Category> categoryList = new List<Category>()
        {
         new Category() {CategoryId = 1, Nome = "Felipe"},
         new Category() {CategoryId = 2, Nome = "Jordane"},
         new Category() {CategoryId = 3, Nome = "Jaci Lane"},
         new Category() {CategoryId = 4, Nome = "Jordão"},
         new Category() {CategoryId = 5, Nome = "Vitor"}
        };

        //GET: CATEGORIES
        public ActionResult Index()
        {
            return View(categoryList);
        }

        //EDIT
        public ActionResult Edit(int id)
        {
            var category = categoryList.Where(c => c.CategoryId == id).First();
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var categories = categoryList.Where(c => c.CategoryId == category.CategoryId).First();
            categories.Nome = category.Nome;
            return RedirectToAction("Index");
        }

        //DELETE
        public ActionResult Delete (long id)
        {
            var category = categoryList.Where(c => c.CategoryId == id).First();
            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete (Category category)
        {
            categoryList.Remove(
            category = categoryList.Where(c => c.CategoryId == category.CategoryId).First());
          
            return RedirectToAction("Index");
        }

        //DETAILS
        public ActionResult Details (long id)
        {
            var category = categoryList.Where(c => c.CategoryId == id).First();
            return View(category);
        }

        //CREATE
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Category category)
        {
            categoryList.Add(category);
            var categories = categoryList.Where(c => c.CategoryId == category.CategoryId).First();

            return RedirectToAction("Index");
        }

    }
}

