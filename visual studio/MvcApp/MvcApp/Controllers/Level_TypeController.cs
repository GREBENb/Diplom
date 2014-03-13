using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class Level_TypeController : Controller
    {
        private DataManager dm = new DataManager();

        //
        // GET: /Level_Type/

        public ActionResult Index()
        {
            return View(dm.Get_Level_Type());
        }

        
        //
        // GET: /Level_Type/Details/5

        public ActionResult Details(Guid id)
        {
            return View(dm.Level_Type_Get_Element(id));
        }

        //
        // GET: /Level_Type/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Level_Type/Create

        [HttpPost]
        public ActionResult Create(Level_type level_type)
        {
            if (ModelState.IsValid)
            {
                level_type.ID = Guid.NewGuid();
                dm.Level_Type_Create(level_type);
                dm.Save();
                return RedirectToAction("Index");
            }

            return View(level_type);
        }

        //
        // GET: /Level_Type/Edit/5

        public ActionResult Edit(Guid id)
        {
            Level_type Level_type = dm.Level_Type_Get_Element(id);
            return View(Level_type);
        }

        //
        // POST: /Level_Type/Edit/5

        [HttpPost]
        public ActionResult Edit(Level_type level_type)
        {
            if (ModelState.IsValid)
            {
                dm.Level_Type_Edit(level_type);
                dm.Save();
                return RedirectToAction("Index");
            }
            return View(level_type);
        }

        //
        // GET: /Level_Type/Delete/5

        public ActionResult Delete(Guid id)
        {
            Level_type level_type = dm.Level_Type_Get_Element(id);
            return View(level_type);
        }

        //
        // POST: /Level_Type/Delete/5

         [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Level_type level_type)
        {
            dm.Level_Type_Delete(level_type);
            return RedirectToAction("Index");

        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}