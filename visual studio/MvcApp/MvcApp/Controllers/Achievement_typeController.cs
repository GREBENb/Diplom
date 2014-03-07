using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class Achievement_typeController : Controller
    {
        private testEntities db = new testEntities();

        //
        // GET: /Achievement_type/

        public ActionResult Index()
        {
            return View(db.Achievement_type.ToList());
        }

        //
        // GET: /Achievement_type/Details/5

        public ActionResult Details(Guid id )
        {
            Achievement_type achievement_type = db.Achievement_type.Find(id);
            if (achievement_type == null)
            {
                return HttpNotFound();
            }
            return View(achievement_type);
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
                db.Achievement_type.Add(achievement_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(achievement_type);
        }

        //
        // GET: /Achievement_type/Edit/5

        public ActionResult Edit(Guid id )
        {
            Achievement_type achievement_type = db.Achievement_type.Find(id);
            if (achievement_type == null)
            {
                return HttpNotFound();
            }
            return View(achievement_type);
        }

        //
        // POST: /Achievement_type/Edit/5

        [HttpPost]
        public ActionResult Edit(Achievement_type achievement_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(achievement_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(achievement_type);
        }

        //
        // GET: /Achievement_type/Delete/5

        public ActionResult Delete(Guid id )
        {
            Achievement_type achievement_type = db.Achievement_type.Find(id);
            if (achievement_type == null)
            {
                return HttpNotFound();
            }
            return View(achievement_type);
        }

        //
        // POST: /Achievement_type/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Achievement_type achievement_type = db.Achievement_type.Find(id);
            db.Achievement_type.Remove(achievement_type);
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