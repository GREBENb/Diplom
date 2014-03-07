using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class AchievementController : Controller
    {
        private testEntities db = new testEntities();

        //
        // GET: /Achievement/

        public ActionResult Index()
        {
            var achievements = db.Achievements.Include(a => a.Organisator).Include(a => a.Level_type).Include(a => a.Achievement_type);
            return View(achievements.ToList());
        }

        //
        // GET: /Achievement/Details/5

        public ActionResult Details(Guid id )
        {
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        //
        // GET: /Achievement/Create

        public ActionResult Create()
        {
            ViewBag.Organisator_id = new SelectList(db.Organisators, "ID", "Name");
            ViewBag.Level_type_id = new SelectList(db.Level_type, "ID", "Name");
            ViewBag.Achievement_type_id = new SelectList(db.Achievement_type, "ID", "Name");
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
                db.Achievements.Add(achievement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Organisator_id = new SelectList(db.Organisators, "ID", "Name", achievement.Organisator_id);
            ViewBag.Level_type_id = new SelectList(db.Level_type, "ID", "Name", achievement.Level_type_id);
            ViewBag.Achievement_type_id = new SelectList(db.Achievement_type, "ID", "Name", achievement.Achievement_type_id);
            return View(achievement);
        }

        //
        // GET: /Achievement/Edit/5

        public ActionResult Edit(Guid id )
        {
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            ViewBag.Organisator_id = new SelectList(db.Organisators, "ID", "Name", achievement.Organisator_id);
            ViewBag.Level_type_id = new SelectList(db.Level_type, "ID", "Name", achievement.Level_type_id);
            ViewBag.Achievement_type_id = new SelectList(db.Achievement_type, "ID", "Name", achievement.Achievement_type_id);
            return View(achievement);
        }

        //
        // POST: /Achievement/Edit/5

        [HttpPost]
        public ActionResult Edit(Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(achievement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Organisator_id = new SelectList(db.Organisators, "ID", "Name", achievement.Organisator_id);
            ViewBag.Level_type_id = new SelectList(db.Level_type, "ID", "Name", achievement.Level_type_id);
            ViewBag.Achievement_type_id = new SelectList(db.Achievement_type, "ID", "Name", achievement.Achievement_type_id);
            return View(achievement);
        }

        //
        // GET: /Achievement/Delete/5

        public ActionResult Delete(Guid id )
        {
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        //
        // POST: /Achievement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Achievement achievement = db.Achievements.Find(id);
            db.Achievements.Remove(achievement);
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