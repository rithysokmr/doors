using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doors.Models
{
    public class DebitNoteProductModel
    {
        public DebitNoteModel Debit_Note { get; set; }
        public List<Debit_Product> DebitProductList { get; set; }
    }
}