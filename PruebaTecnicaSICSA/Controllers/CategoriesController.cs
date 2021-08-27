using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnicaSICSA.Models;
using MySql.Data;


namespace PruebaTecnicaSICSA.Controllers
{
    public class CategoriesController : Controller
    {
        private PruebaSicsaEntities1 dbContext = new PruebaSicsaEntities1();
        // GET: Categories
        public ActionResult Index(string Message, string typeMessage)
        {
            ViewBag.Message = Message;
            ViewBag.TypeMessage = typeMessage;
            ViewBag.Categories = dbContext.categories.ToList();

            return View();
        }

        // GET: Categories/Details/5


        // GET: Categories/Create
        public ActionResult getCreate()
        {
            category category = new category();
            return PartialView("_create", category);
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(category category)
        {
            try
            {


                category.Description = category.Description != null ? category.Description : string.Empty;
                dbContext.categories.Add(category);

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

        // GET: Categories/Edit/5
        public ActionResult GetEdit(int id)
        {
            category category = dbContext.categories.Where(x => x.CategoryId == id).FirstOrDefault();
            return PartialView("_Edit", category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(category category)
        {
            try
            {

                if (category != null)
                {
                    category.Description = category.Description != null ? category.Description : string.Empty;
                    dbContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
                    if (dbContext.SaveChanges() == 1)
                        return RedirectToAction("Index", routeValues: new { Message = "La información se guardo correctamente.", typeMessage = "alert alert-success" });
                    else
                        return RedirectToAction("Index", routeValues: new { Message = "Error al guardar informacion.", typeMessage = "alert alert-warning" });
                }
                else
                {
                    return RedirectToAction("Index", routeValues: new { Message = "No encontró el producto.", typeMessage = "alert alert-warning" });

                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", routeValues: new { Message = ex.Message, typeMessage = "alert alert-danger" });
            }
        }

        // GET: Categories/Delete/5


        // POST: Categories/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                bool hasProducts = dbContext.products.Any(x => x.CategoryId == id);
                if (!hasProducts)
                {
                    category category = dbContext.categories.Where(x => x.CategoryId == id).FirstOrDefault();
                    dbContext.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                    dbContext.SaveChanges();

                    if (dbContext.SaveChanges() == 0)
                        return RedirectToAction("Index", routeValues: new { Message = "La información se elimino correctamente.", typeMessage = "alert alert-success" });
                    else
                        return RedirectToAction("Index", routeValues: new { Message = "Error al borrar la informacion.", typeMessage = "alert alert-warning" });
                }

                else
                    return RedirectToAction("Index", routeValues: new { Message = "No se puede realizar la operacion.", typeMessage = "alert alert-warning" });

                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", routeValues: new { Message = ex.Message, typeMessage = "alert alert-danger" });
            }
        }
    }
}
