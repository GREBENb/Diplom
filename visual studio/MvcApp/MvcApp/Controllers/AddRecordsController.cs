using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class AddRecordsController : Controller
    {

        private DataManager dm = new DataManager();
        //
        // GET: /AddRecords/

        

        public ActionResult Fill()
        {
            dm.AddRecords();
            return View();
        }

        public ActionResult Empty()
        {
            dm.RemoveRecords();
            return View();
        }

    }
}
