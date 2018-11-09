using Doors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Web.Security; 

namespace Doors.Controllers
{
    public class MasterController : Controller
    {
        //
        // GET: /Master/
        public ActionResult Login()
        {
            if (Session["UserName"] != null)
            {
                return View("Home");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel objUser)
        {
            if (ModelState.IsValid)
            {
                using (DoorEntities db = new DoorEntities())
                {
                    var obj = db.Users.Where(a => a.username.Equals(objUser.username) && a.end_date > DateTime.Now).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.user_id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return View("Home");
                    }
                }
            }
            ViewBag.Message = "Invalide Username or Password";
            return View(objUser);
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            return RedirectToAction("Login", "Master");
        }
	}
}