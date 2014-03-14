using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class ClassgroupController : Controller
    {

        private DataManager dm = new DataManager();
        //
        // GET: /Classgroup/

        public ActionResult Index()
        {
            return View(dm.Get_Classgroup());
        }

        //
        // GET: /Organisator/Details/5


        
        public ActionResult Details(Guid id)
        {
            return View(dm.Classgroup_Get_Element(id));
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
        public ActionResult Create(Classgroup Classgroup)
        {if (ModelState.IsValid)
            {
               Classgroup.ID = Guid.NewGuid();
               dm.Classgroup_Create(Classgroup);
               dm.Save();
               return RedirectToAction("Index");
            }
        return View(Classgroup);
        }

        //
        // GET: /Organisator/Edit/5


        public ActionResult Edit(Guid id)
        {
            Classgroup Classgroup = dm.Classgroup_Get_Element(id);
            return View(Classgroup);
        }

        //
        // POST: /Organisator/Edit/5

        [HttpPost]
        public ActionResult Edit(Classgroup Classgroup)
        {
            if (ModelState.IsValid)
            {
                dm.Classgroup_Edit(Classgroup);
                dm.Save();
                return RedirectToAction("Index");
            }
            return View(Classgroup);
        }

        //
        // GET: /Organisator/Delete/5


        public ActionResult Delete(Guid id)
        {
            Classgroup Classgroup = dm.Classgroup_Get_Element(id);
            return View(Classgroup);
        }


        //
        // POST: /Organisator/Delete/5




        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Classgroup Classgroup)
        {
            dm.Classgroup_Delete(Classgroup);
            return RedirectToAction("Index");

        }


        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}

    }
}
