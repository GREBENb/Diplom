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
    public class SemestrController : Controller
    {
        private DataManager dm = new DataManager();

        //
        // GET: /Semestr/

        public ActionResult Index()
        {
            return View(dm.Get_Semestr());
        }

                
        //
        // GET: /Semestr/Details/5

        public ActionResult Details(Guid id)
        {
            return View(dm.Semestr_Get_Element(id));
        }

        //
        // GET: /Semestr/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Semestr/Create

        [HttpPost]
        public ActionResult Create(Semestr semestr)
        {
            if (ModelState.IsValid)
            {
                semestr.ID = Guid.NewGuid();
                dm.Semestr_Create(semestr);
                dm.Save();
                return RedirectToAction("Index");
            }

            return View(semestr);
        }

        //
        // GET: /Semestr/Edit/5

        public ActionResult Edit(Guid id)
        {
            Semestr semestr = dm.Semestr_Get_Element(id);
            return View(semestr);
        }

        //
        // POST: /Semestr/Edit/5

        [HttpPost]
        public ActionResult Edit(Semestr semestr)
        {
            if (ModelState.IsValid)
            {
                dm.Semestr_Edit(semestr);
                dm.Save();
                return RedirectToAction("Index");
            }
            return View(semestr);
        }

        //
        // GET: /Semestr/Delete/5

        public ActionResult Delete(Guid id)
        {
            Semestr semestr = dm.Semestr_Get_Element(id);
            return View(semestr);
        }

        //
        // POST: /Semestr/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Semestr semestr)
        {
            dm.Semestr_Delete(semestr);
            return RedirectToAction("Index");

        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}