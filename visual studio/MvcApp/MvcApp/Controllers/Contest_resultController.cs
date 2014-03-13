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
    public class Contest_resultController : Controller
    {
        //private testEntities dm = new testEntities();
        private DataManager dm = new DataManager();
        //
        // GET: /Contest_result/

        public ActionResult Index()
        {
            return View(dm.Get_Contest_Results());
        }


        //// GET: /Contest_result/Details/5

        public ActionResult Details(Guid id)
        {
            return View(dm.Contest_Result_Get_Element(id));
        }


        ////
        //// GET: /Contest_result/Create


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
                dm.Contest_Result_Create(contest_result);
                dm.Save();
                return RedirectToAction("Index");
            }
           
            return View(contest_result);
        }

        //
        // GET: /Contest_result/Edit/5

        public ActionResult Edit(Guid id)
        {
            Contest_result contest_result = dm.Contest_Result_Get_Element(id);
            return View(contest_result);
        }





        //  POST: /Contest_result/Edit/5

        [HttpPost]
        public ActionResult Edit(Contest_result contest_result)
        {
            if (ModelState.IsValid)
            {
                dm.Contest_resultEdit(contest_result);
                dm.Save();
                return RedirectToAction("Index");
            }
            return View(contest_result);
        }

        //
        // GET: /Contest_result/Delete/5

        public ActionResult Delete(Guid id)
        {
            Contest_result contest_result = dm.Contest_Result_Get_Element(id);
            return View(contest_result);
        }




        // POST: /Contest_result/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Contest_result contest_result)
        {
            dm.Contest_Result_Delete(contest_result);
            return RedirectToAction("Index");

        }



        //protected override void Dispose(bool disposing)
        //{
        //    dm.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}