using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doors.Models
{
    public class DebitNoteModel
    {
        public int id { get; set; }
        public int debit_id { get; set; }
        public string debit_fullId { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public string create_by { get; set; }
        public Nullable<System.DateTime> create_on { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> paying_date { get; set; }
        public string reference { get; set; }
        public Nullable<System.DateTime> record_date { get; set; }
        public string customer_name { get; set; }
        public string billing_to { get; set; }
        public string cust_address { get; set; }
        public string customer_phone { get; set; }
        public string bl { get; set; }
        public string container_number { get; set; }
        public string commodity { get; set; }
        public string package_number { get; set; }
        public string vessel { get; set; }
        public string voy { get; set; }
        public Nullable<double> advance_money { get; set; }

    }
}