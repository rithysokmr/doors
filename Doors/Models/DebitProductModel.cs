using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doors.Models
{
    public class DebitProductModel
    {
        public int product_id { get; set; }
        public int debit_id { get; set; }
        public int debit_full_id { get; set; }
        public Nullable<int> order_number { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_on { get; set; }
        public string product_name { get; set; }
        public Nullable<double> product_amount { get; set; }
        public string product_amount_type { get; set; }
        public Nullable<double> pro_unit_price { get; set; }
        public Nullable<double> vate { get; set; }
        public Nullable<double> total_price { get; set; }
        public string extra { get; set; }
    }
}