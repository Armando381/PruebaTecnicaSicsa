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
        public ActionResult Create()
        {

            return PartialView("_create");
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(string CategoryName, string Description)
        {
            try
            {
                category cat = new category();
                cat.Description = Description;
                cat.Name = CategoryName;

                dbContext.categories.Add(cat);

                if (dbContext.SaveChanges() == 1)
                    return RedirectToAction("Index", routeValues:new { Message="La información se guardo correctamente", typeMessage="success" }) ;
                else
                    throw new ApplicationException("Error al guardar informacion;");
            }
            catch(Exception ex)
            {
                throw ;
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CatId = id;
            return View();
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string Name, string description)
        {
            try
            {
                category cat = dbContext.categories.Where(x => x.CategoryId == id).FirstOrDefault();
                if (cat!=null)
                {
                    cat.Description = description;
                    cat.Name = Name;
                    dbContext.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                    if (dbContext.SaveChanges() == 1)
                        return RedirectToAction("Index");
                    else
                        throw new ApplicationException("Error al guardar informacion;");
                }
                else
                {
                    throw new ApplicationException("No encontró el producto");
                }
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // GET: Categories/Delete/5
        public ActionResult GetDelete(int id)
        {
           bool hasProducts = dbContext.products.Any(x => x.CategoryId == id);
            if (hasProducts)
                return View();
            else
                throw new ApplicationException("No se puede realizar la operacion.");
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                category cat = dbContext.categories.Where(x => x.CategoryId == id).FirstOrDefault();
                dbContext.Entry(cat).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();

                if (dbContext.SaveChanges() == 1)
                    return RedirectToAction("Index");
                else
                    throw new ApplicationException("Error al guardar informacion;");
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
