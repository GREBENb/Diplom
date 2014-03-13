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
    public class Achievement_typeController : Controller
    {
        private DataManager dm = new DataManager();

        //
        // GET: /Achievement_type/

        public ActionResult Index()
        {
            return View(dm.Get_Achievement_Type());
        }

        //
        // GET: /Achievement_type/Details/5

        public ActionResult Details(Guid id)
        {
            return View(dm.Achievement_Type_Get_Element(id));
        }

        //
        // GET: /Achievement_type/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Achievement_type/Create

        [HttpPost]
        public ActionResult Create(Achievement_type achievement_type)
        {
            if (ModelState.IsValid)
            {
                achievement_type.ID = Guid.NewGuid();
                dm.Achievement_Type_Create(achievement_type);
                dm.Save();
                return RedirectToAction("Index");
            }

            return View(achievement_type);
        }

        //
        // GET: /Achievement_type/Edit/5

        public ActionResult Edit(Guid id)
        {
            Achievement_type achievement_type = dm.Achievement_Type_Get_Element(id);
            return View(achievement_type);
        }

        //
        // POST: /Achievement_type/Edit/5

        [HttpPost]
        public ActionResult Edit(Achievement_type achievement_type)
        {
            if (ModelState.IsValid)
            {
                dm.Achievement_Type_Edit(achievement_type);
                dm.Save();
                return RedirectToAction("Index");
            }
            return View(achievement_type);
        }

        //
        // GET: /Achievement_type/Delete/5

        public ActionResult Delete(Guid id)
        {
            Achievement_type achievement_type = dm.Achievement_Type_Get_Element(id);
            return View(achievement_type);
        }

        //
        // POST: /Achievement_type/Delete/5



        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(Achievement_type Achievement_type)
        {
            dm.Achievement_Type_Delete(Achievement_type);
            return RedirectToAction("Index");
        }
          
      

    
        //protected override void Dispose(bool disposing)
        
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}