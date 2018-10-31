using Doors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity; 

namespace Doors.Controllers
{
    public class UsersController : Controller
    {
        DoorEntities db = new DoorEntities();
        public User temUserData;
        //
        // GET: /Users/
        public ActionResult Index()
        {
           // User tbl = new User();
            //var UserList = db.Users.ToList();

            return View();
        }

        public ActionResult LoadUser()
        {
            using (DoorEntities doorDB = new DoorEntities())
            {
                List<User> UserList = doorDB.Users.Where( x => x.end_date > DateTime.Now ).ToList<User>();
                return Json(new { data = UserList}, JsonRequestBehavior.AllowGet);
            }
        }
        //
        // GET: /Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Users/Create
        public ActionResult EditUsers(int id = 0)
        {
            //this.AddEditViewUsers(id, "true");  // enable input 
            return RedirectToAction("AddEditViewUsers", "Users", new { @id = id, @enable = "true" });
            
        }
        public ActionResult ViewUsers(int id = 0)
        {
            return RedirectToAction("AddEditViewUsers", "Users", new { @id = id, @enable = "false" });
        }
        public ActionResult AddEditViewUsers( int id = 0, string enable = "false")
        {

            if (id == 0)
            {
                return View();
            }
            else
            {
                using (DoorEntities db = new DoorEntities())
                {
                    temUserData = db.Users.Where(x => x.user_id == id ).FirstOrDefault<User>();
                    ViewData["input"] = enable;
                    return View(temUserData);
                    //UsersModel userData = new UsersModel();
                    //return View(userData);
                }
            }
            
        }
        public User GetUser( int id = 0 )
        {
            using (DoorEntities db = new DoorEntities())
            {
                User oldUserData = db.Users.Where(x => x.user_id == id).FirstOrDefault<User>();
                return oldUserData;
            }
        }
        //
        // POST: /Users/Create
        [HttpPost]
        public ActionResult AddEditViewUsers(User userData)
        {
            try
            {
                // TODO: Add insert logic here
                using (DoorEntities db = new DoorEntities())
                {
                    if (userData.user_id == 0)
                    {
                        db.Users.Add(userData);

                        userData.beg_date = DateTime.Now;
                        userData.end_date = Convert.ToDateTime("May 01 9999");
                        userData.create_by = "rithy";
                        userData.create_on = DateTime.Now;
                        userData.last_change_by = "rithy";
                        userData.last_change_on = DateTime.Now;

                        db.SaveChanges();
                        //return RedirectToAction("Index");
                        return Json(new { success = true, message = "Save Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //db.Entry(userData).State = EntityState.Modified;
                        
                        // modify old data of end date to yesterday
                        this.UpdateOldUserData( userData.user_id );

                        db.Users.Add(userData);
                        userData.beg_date = DateTime.Now;
                        userData.last_change_by = "reach";  //temUserData.create_by;
                        userData.last_change_on = DateTime.Now;

                        db.SaveChanges();
                        return Json(new { success = true, message = "Update Successfully"}, JsonRequestBehavior.AllowGet);
                    }
                }
                
            }
            catch
            {
                return View();
            }
        }
        public void UpdateOldUserData( int id = 0 )
        {
            User old_data = this.GetUser(id);
            db.Entry(old_data).State = EntityState.Modified;
            old_data.end_date = DateTime.Now;
            db.SaveChanges();
        }
        //
        // GET: /Users/Edit/5
        public ActionResult Edit(int id​​ = 0)
        {
            if (id == 0)
            {
                return View("Index");
            } else {
                using (DoorEntities db = new DoorEntities())
                {
                    temUserData = db.Users.Where(x => x.user_id == id).FirstOrDefault<User>();
                    return View(temUserData);
                }
                
            }
        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Delete/5
       /* public ActionResult Delete(int id)
        {
            return View();
        }
        */
        //
        // POST: /Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                using (DoorEntities db = new DoorEntities())
                {
                    //User userData = db.Users.Where( x => x.user_id == id).FirstOrDefault<User>();
                    //userData.end_date = DateTime.Now;
                    var userUpdate = new User() { user_id = id, end_date = DateTime.Now, last_change_by = "rithy2", last_change_on = DateTime.Now };
                    db.Users.Attach(userUpdate);
                    db.Entry(userUpdate).Property(x => x.end_date).IsModified = true;
                    db.Entry(userUpdate).Property(x => x.last_change_on).IsModified = true;
                    db.Entry(userUpdate).Property(x => x.last_change_by).IsModified = true;
                    //db.Users.Remove(userData);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Delete user successfully"}, JsonRequestBehavior.AllowGet);
                }
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
