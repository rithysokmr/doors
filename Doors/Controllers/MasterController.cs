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
         [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Session["UserName"] != null)
            {
                return View("Home");
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
            
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel objUser, string returnUrl)
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
                        FormsAuthentication.SetAuthCookie(objUser.username, true);
                        string ReturnUrl = Convert.ToString(Request.QueryString["url"]);  
                        if (!string.IsNullOrWhiteSpace(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
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