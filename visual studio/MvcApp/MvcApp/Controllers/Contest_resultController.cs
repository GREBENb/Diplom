using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class Contest_resultController : Controller
    {
        private testEntities db = new testEntities();

        //
        // GET: /Contest_result/

        public ActionResult Index()
        {
            return View(db.Contest_result.ToList());
        }

        //
        // GET: /Contest_result/Details/5

        public ActionResult Details(Guid id )
        {
            Contest_result contest_result = db.Contest_result.Find(id);
            if (contest_result == null)
            {
                return HttpNotFound();
            }
            return View(contest_result);
        }

        //
        // GET: /Contest_result/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contest_result/Create

        [HttpPost]
        public ActionResult Create(Contest_result contest_result)
        {
            if (ModelState.IsValid)
            {
                contest_result.ID = Guid.NewGuid();
                db.Contest_result.Add(contest_result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contest_result);
        }

        //
        // GET: /Contest_result/Edit/5

        public ActionResult Edit(Guid id )
        {
            Contest_result contest_result = db.Contest_result.Find(id);
            if (contest_result == null)
            {
                return HttpNotFound();
            }
            return View(contest_result);
        }

        //
        // POST: /Contest_result/Edit/5

        [HttpPost]
        public ActionResult Edit(Contest_result contest_result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contest_result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contest_result);
        }

        //
        // GET: /Contest_result/Delete/5

        public ActionResult Delete(Guid id)
        {
            Contest_result contest_result = db.Contest_result.Find(id);
            if (contest_result == null)
            {
                return HttpNotFound();
            }
            return View(contest_result);
        }

        //
        // POST: /Contest_result/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Contest_result contest_result = db.Contest_result.Find(id);
            db.Contest_result.Remove(contest_result);
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