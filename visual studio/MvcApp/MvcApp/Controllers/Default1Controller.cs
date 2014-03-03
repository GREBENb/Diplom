using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class Default1Controller : Controller
    {
        private testEntities db = new testEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.Semestrs.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(Guid id = null)
        {
            Semestr semestr = db.Semestrs.Find(id);
            if (semestr == null)
            {
                return HttpNotFound();
            }
            return View(semestr);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Semestr semestr)
        {
            if (ModelState.IsValid)
            {
                semestr.ID = Guid.NewGuid();
                db.Semestrs.Add(semestr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semestr);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(Guid id = null)
        {
            Semestr semestr = db.Semestrs.Find(id);
            if (semestr == null)
            {
                return HttpNotFound();
            }
            return View(semestr);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Semestr semestr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semestr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semestr);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(Guid id = null)
        {
            Semestr semestr = db.Semestrs.Find(id);
            if (semestr == null)
            {
                return HttpNotFound();
            }
            return View(semestr);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Semestr semestr = db.Semestrs.Find(id);
            db.Semestrs.Remove(semestr);
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