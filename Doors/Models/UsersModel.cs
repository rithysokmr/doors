using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doors.Models
{
    public class UsersModel
    {
        public int user_id { get; set; }
        [Remote("IsUserNameExist", "Users", ErrorMessage = "This Username already exist")]
        [Required(ErrorMessage = "Required field")]
        public string username { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string password { get; set; }
        public string fullname { get; set; }
        public string sex { get; set; }
        public string role { get; set; }
        [DataType(DataType.MultilineText)]
        public string personal_info { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> create_on { get; set; }
        public string last_change_by { get; set; }
        public Nullable<System.DateTime> last_change_on { get; set; }
        public string extra { get; set; }
        public Nullable<System.DateTime> beg_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
    }
}