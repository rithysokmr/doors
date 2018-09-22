using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doors.Models
{
    public class Users
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string sex { get; set; }
        public string role { get; set; }
        public string personal_info { get; set; }
    }
}