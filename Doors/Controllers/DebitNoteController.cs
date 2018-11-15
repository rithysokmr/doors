using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doors.Models;

namespace Doors.Controllers
{
    public class DebitNoteController : Controller
    {
        //
        // GET: /DebitNote/
        public ActionResult Index()
        {
            return View();
        }
        // GET: /DebitNote/
        public ActionResult AddEditViewDebit()
        {
            return View();
        }
	}
}