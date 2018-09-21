using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doors.Controllers
{
    public class MasterController : Controller
    {
        //
        // GET: /Master/
        public ActionResult Index()
        {
            return View("../User/AddUsers");
        }
        public ActionResult UserMG()
        {
            return View("../User/Index");
        }
	}
}