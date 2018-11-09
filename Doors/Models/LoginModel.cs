using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doors.Models
{
    public class LoginModel
    {
        public int user_id { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string username { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string password { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
    }
}