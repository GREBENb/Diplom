using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class Level_TypeController : Controller
    {
        private testEntities db = new testEntities();

        //
        // GET: /Level_Type/

        public ActionResult Index()
        {
            return View(db.Level_type.ToList());
        }

        //
        // GET: /Level_Type/Details/5

        public ActionResult Details(Guid id)
        {
            Level_type level_type = db.Level_type.Find(id);
            if (level_type == null)
            {
                return HttpNotFound();
            }
            return View(level_type);
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
                db.Level_type.Add(level_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(level_type);
        }

        //
        // GET: /Level_Type/Edit/5

        public ActionResult Edit(Guid id)
        {
            Level_type level_type = db.Level_type.Find(id);
            if (level_type == null)
            {
                return HttpNotFound();
            }
            return View(level_type);
        }

        //
        // POST: /Level_Type/Edit/5

        [HttpPost]
        public ActionResult Edit(Level_type level_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(level_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(level_type);
        }

        //
        // GET: /Level_Type/Delete/5

        public ActionResult Delete(Guid id )
        {
            Level_type level_type = db.Level_type.Find(id);
            if (level_type == null)
            {
                return HttpNotFound();
            }
            return View(level_type);
        }

        //
        // POST: /Level_Type/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Level_type level_type = db.Level_type.Find(id);
            db.Level_type.Remove(level_type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}