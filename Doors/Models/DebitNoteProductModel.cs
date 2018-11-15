using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doors.Models
{
    public class DebitNoteProductModel
    {
        public DeditNoteModel Debit_Note { get; set; }
        public List<DebitProductModel> DebitProductList { get; set; }
    }
}