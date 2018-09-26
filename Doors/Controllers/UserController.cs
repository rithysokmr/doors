﻿using Doors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doors.Controllers
{
    public class UserController : Controller
    {
        
        //
        // GET: /User/
        public ActionResult Index()
        {
            DoorEntities db = new DoorEntities();

            var users = db.users.ToList();

            Users loginUser = new Users();

            loginUser.user_id = users.user_id;
            loginUser.username = users.username;
            loginUser.fullname = users.fullname;

            return View(loginUser);
        }
	}
}