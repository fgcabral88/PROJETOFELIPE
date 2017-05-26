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
    public class SuppliersController : Controller
    {
        private EFContext context = new EFContext();

        // GET: SUPPLIERS 
        public ActionResult Index()
        {

           return View(context.Suppliers.OrderBy(c => c.Nome));
        }

        //CREATE
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Create (Supplier Supplier)
        {
            context.Suppliers.Add(Supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //EDIT
        public ActionResult Edit(long? id)
        {
            if(id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Supplier Supplier = context.Suppliers.Find(id);
            if (Supplier == null)
            {
                return HttpNotFound();
            }
            return View(Supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Supplier Supplier)
        {
            if (ModelState.IsValid)
            {
                context.Entry(Supplier).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Supplier);
        }
        //DETAILS
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest);
            }
            Supplier Supplier = context.Suppliers.Where(f => f.SupplierId == id).Include("Products.Category").First();
            if(Supplier == null)
            {
                return HttpNotFound();
            }
            return View(Supplier);
        }
        //DELETE
        public ActionResult Delete (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Supplier Supplier = context.Suppliers.Find(id);
            if (Supplier == null)
            {
                return HttpNotFound();
            }
            return View(Supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (long id)
        {
            Supplier Supplier = context.Suppliers.Find(id);
            context.Suppliers.Remove(Supplier);
            context.SaveChanges();
            TempData["Message"] = "Suppliers" + Supplier.Nome.ToUpper() + "Foi removido";
            return RedirectToAction("Index");
        }
    }
}