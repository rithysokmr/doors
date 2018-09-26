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
        public string create_by { get; set; }
        public Nullable<System.DateTime> create_on { get; set; }
        public string last_change_by { get; set; }
        public Nullable<System.DateTime> last_change_on { get; set; }
        public string extra { get; set; }
    }
}