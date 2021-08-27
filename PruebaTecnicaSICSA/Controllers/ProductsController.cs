using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnicaSICSA.Models;

namespace PruebaTecnicaSICSA.Controllers
{
    public class ProductsController : Controller
    {
        private PruebaSicsaEntities1 dbContext = new PruebaSicsaEntities1();
        // GET: products
        public ActionResult Index(string Message, string typeMessage)
        {
            ViewBag.Message = Message;
            ViewBag.TypeMessage = typeMessage;
            ViewBag.Categories = dbContext.products.ToList();

            return View();
        }
        // GET: Products/Details/5


        // GET: Products/Create
        public ActionResult Create()
        {
            product product = new product();

            ViewData["CategoryId"] = dbContext.categories.Select(x => new SelectListItem() { Value = x.CategoryId.ToString(), Text = x.Name });
            return PartialView("_Create", product);
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(product product)
        {
            try
            {

                dbContext.products.Add(product);

                if (dbContext.SaveChanges() == 1)
                    return RedirectToAction("Index", routeValues: new { Message = "La información se guardo correctamente.", typeMessage = "alert alert-success" });
                else
                    return RedirectToAction("Index", routeValues: new { Message = "Error al guardar informacion.", typeMessage = "alert alert-warning" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", routeValues: new { Message = ex.Message, typeMessage = "alert alert-danger" });
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            product products = dbContext.products.Where(x => x.ProductId == id).FirstOrDefault();

            return PartialView("_Edit", products);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(product product)
        {
            try
            {

                dbContext.Entry(product).State = System.Data.Entity.EntityState.Modified;


                if (dbContext.SaveChanges() == 1)
                    return RedirectToAction("Index", routeValues: new { Message = "La información se guardo correctamente.", typeMessage = "alert alert-success" });
                else
                    return RedirectToAction("Index", routeValues: new { Message = "Error al guardar informacion.", typeMessage = "alert alert-warning" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", routeValues: new { Message = ex.Message, typeMessage = "alert alert-danger" });
            }
        }

        // GET: Products/Delete/5
        public ActionResult getDelete(int id)
        {
            product product = dbContext.products.Where(x => x.ProductId == id).FirstOrDefault();
            return RedirectToAction("Delete", routeValues: new { product = product });
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(product product)
        {

            try
            {

                dbContext.Entry(product).State = System.Data.Entity.EntityState.Modified;

                if (dbContext.SaveChanges() == 1)
                    return RedirectToAction("Index", routeValues: new { Message = "La información se guardo correctamente.", typeMessage = "alert alert-success" });
                else
                    return RedirectToAction("Index", routeValues: new { Message = "Error al guardar informacion.", typeMessage = "alert alert-warning" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", routeValues: new { Message = ex.Message, typeMessage = "alert alert-danger" });
            }


        }
    }
}
