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
    public class OrganisatorController : Controller
    {
        private DataManager dm = new DataManager();

        //
        // GET: /Organisator/
        public ActionResult Index()
        {
            return View(dm.Get_Organisator());
        }
        
          
       //
      // GET: /Organisator/Details/5


        public ActionResult Details(Guid id)
        {
            return View(dm.Organisator_Get_Element(id));
             
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
                dm.Organisator_Create(organisator);
                dm.Save();
                return RedirectToAction("Index");
            }

            return View(organisator);
        }


        //
        // GET: /Organisator/Edit/5


        public ActionResult Edit(Guid id)
        {
            Organisator organisator = dm.Organisator_Get_Element(id);
            return View(organisator);
        }



        //
        // POST: /Organisator/Edit/5

        [HttpPost]
        public ActionResult Edit(Organisator organisator)
        {
            if (ModelState.IsValid)
            {
                dm.Organisator_Edit(organisator);
                dm.Save();
                return RedirectToAction("Index");
            }
            return View(organisator);
        }

        //
        // GET: /Organisator/Delete/5

        public ActionResult Delete(Guid id)
        {
            Organisator organisator = dm.Organisator_Get_Element(id);
            return View(organisator);
        }
        

        //
        // POST: /Organisator/Delete/5


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Organisator organistor)
        {
            dm.Organisator_Delete(organistor);
            return RedirectToAction("Index");

        }



        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}