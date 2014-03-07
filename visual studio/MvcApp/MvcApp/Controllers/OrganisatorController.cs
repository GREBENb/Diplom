using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class OrganisatorController : Controller
    {
        private testEntities db = new testEntities();

        //
        // GET: /Organisator/

        public ActionResult Index()
        {
            return View(db.Organisators.ToList());
        }

        //
        // GET: /Organisator/Details/5

        public ActionResult Details(Guid id)
        {
            Organisator organisator = db.Organisators.Find(id);
            if (organisator == null)
            {
                return HttpNotFound();
            }
            return View(organisator);
        }

        //
        // GET: /Organisator/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Organisator/Create

        [HttpPost]
        public ActionResult Create(Organisator organisator)
        {
            if (ModelState.IsValid)
            {
                organisator.ID = Guid.NewGuid();
                db.Organisators.Add(organisator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organisator);
        }

        //
        // GET: /Organisator/Edit/5

        public ActionResult Edit(Guid id)
        {
            Organisator organisator = db.Organisators.Find(id);
            if (organisator == null)
            {
                return HttpNotFound();
            }
            return View(organisator);
        }

        //
        // POST: /Organisator/Edit/5

        [HttpPost]
        public ActionResult Edit(Organisator organisator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organisator);
        }

        //
        // GET: /Organisator/Delete/5

        public ActionResult Delete(Guid id)
        {
            Organisator organisator = db.Organisators.Find(id);
            if (organisator == null)
            {
                return HttpNotFound();
            }
            return View(organisator);
        }

        //
        // POST: /Organisator/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Organisator organisator = db.Organisators.Find(id);
            db.Organisators.Remove(organisator);
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