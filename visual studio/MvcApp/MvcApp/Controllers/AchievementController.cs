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
    public class AchievementController : Controller
    {
        private DataManager dm = new DataManager();

        //
        // GET: /Achievement/

        public ActionResult Index()
        {
            return View(dm.Get_Achievements());
        }


        //
        // GET: /Achievement/Details/5


        public ActionResult Details(Guid id)
        {
            return View(dm.Achievement_Get_Element(id));
        }


        
       //  GET: /Achievement/Create

        public ActionResult Create()
        {
            ViewBag.Organisator_id = new SelectList(dm.Get_Organisator() , "ID", "Name");
            ViewBag.Level_type_id = new SelectList(dm.Get_Level_Type(), "ID", "Name");
            ViewBag.Achievement_type_id = new SelectList(dm.Get_Achievement_Type(), "ID", "Name");
            return View();
        }

        //
        // POST: /Achievement/Create

        [HttpPost]
        public ActionResult Create(Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                achievement.ID = Guid.NewGuid();
                dm.Achievement_Create(achievement);
                dm.Save();
                return RedirectToAction("Index");
            }



            ViewBag.Organisator_id = new SelectList(dm.Get_Organisator(), "ID", "Name", achievement.Organisator_id);
            ViewBag.Level_type_id = new SelectList(dm.Get_Level_Type(), "ID", "Name", achievement.Level_type_id);
            ViewBag.Achievement_type_id = new SelectList(dm.Get_Achievement_Type(), "ID", "Name", achievement.Achievement_type_id);
            return View(achievement);
        }

        //
        // GET: /Achievement/Edit/5

        public ActionResult Edit(Guid id )
        {
            Achievement achievement = dm.Achievement_Get_Element(id);
            
           
            ViewBag.Organisator_id = new SelectList(dm.Get_Organisator(), "ID", "Name", achievement.Organisator_id);
            ViewBag.Level_type_id = new SelectList(dm.Get_Level_Type(), "ID", "Name", achievement.Level_type_id);
            ViewBag.Achievement_type_id = new SelectList(dm.Get_Achievement_Type(), "ID", "Name", achievement.Achievement_type_id);
            return View(achievement);
        }

        //
        // POST: /Achievement/Edit/5

        [HttpPost]
        public ActionResult Edit(Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                dm.Achievement_Edit(achievement);
                dm.Save();
                return RedirectToAction("Index");
            }
            
        
            ViewBag.Organisator_id = new SelectList(dm.Get_Organisator(), "ID", "Name", achievement.Organisator_id);
            ViewBag.Level_type_id = new SelectList(dm.Get_Level_Type(), "ID", "Name", achievement.Level_type_id);
            ViewBag.Achievement_type_id = new SelectList(dm.Get_Achievement_Type(), "ID", "Name", achievement.Achievement_type_id);
            return View(achievement);
        }

        //
        // GET: /Achievement/Delete/5

        public ActionResult Delete(Guid id)
        {
            Achievement achievement = dm.Achievement_Get_Element(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        //
        // POST: /Achievement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Achievement achievement)
        {
            dm.Achievement_Delete(achievement);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}