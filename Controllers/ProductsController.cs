using Felipe.Contexts;
using Felipe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Felipe.Controllers
{
    using System.Data.Entity;
    public class ProductsController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Products

        public ActionResult Index()
        {
            var products = context.Products.Include(c => c.Category).Include(f => f.Supplier).OrderBy(n => n.Nome);
            return View(products);
        }

        // GET: DETAILS
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId == id).Include(c => c.Category).Include(f => f.Supplier).First();
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: CREATE 
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(b => b.Nome), "CategoryId", "Nome");
            ViewBag.SupplierId = new SelectList(context.Suppliers.OrderBy(b =>b.Nome),"Suppliers", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        // GET: EDIT
        public ActionResult Edit(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(b => b.Nome), "CategoryId", "Nome", product.CategoryId);
            ViewBag.SupplierId = new SelectList(context.Suppliers.OrderBy(b => b.Nome), "SupplierId", "Nome", product.SupplierId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);   
            }
            catch
            {
                return View(product);
            }
        }

        // GET: DELETE
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult (HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId == id).Include(c => c.Category).Include(f => f.Supplier).First();
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
