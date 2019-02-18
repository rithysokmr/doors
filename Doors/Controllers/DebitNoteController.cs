using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doors.Models;

namespace Doors.Controllers
{
    public class DebitNoteController : Controller
    {
        DoorEntities db = new DoorEntities();
        static List<DebitNoteModel> debitPruductData = new List<DebitNoteModel>();
        public Debit_Note temDebitData;
        //
        // GET: /DebitNote/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadDebitNote()
        {
            using (DoorEntities doorDB = new DoorEntities())
            {
                List<Debit_Note> DebitNoteList = doorDB.Debit_Note.Where(x => x.end_date > DateTime.Now).ToList<Debit_Note>();
                //DebitNoteModel usingData = new DebitNoteModel();

               // usingData.debit_id = DebitNoteList.debit

                return Json(new { data = DebitNoteList }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Edit user
        public ActionResult EditDebitNote(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                //return RedirectToAction("AddEditViewDebit", "DebitNote", new { @id = id });
                using (DoorEntities db = new DoorEntities())
                {
                    temDebitData = db.Debit_Note.Where(x => x.id == id).FirstOrDefault<Debit_Note>();

                    Debit_Note debitNote = db.Debit_Note.Where(x => x.id == id).FirstOrDefault<Debit_Note>();
                    DebitNoteModel debitNoteData = new DebitNoteModel();

                    List<Debit_Product> DebitProduct = db.Debit_Product.Where(x => x.debit_id == id ).ToList<Debit_Product>();
                    //static List<DebitNoteModel> debitPruductData = new List<DebitNoteModel>();

                    DebitNoteProductModel DebitNoteProduct = new DebitNoteProductModel();

                    debitNoteData.id            = debitNote.id;
                    debitNoteData.debit_id      = debitNote.debit_id;
                    debitNoteData.start_date    = debitNote.start_date;
                    debitNoteData.end_date      = debitNote.end_date;
                    debitNoteData.create_by     = debitNote.create_by;
                    debitNoteData.create_on     = debitNote.create_on;
                    debitNoteData.edit_by       = debitNote.edit_by;
                    debitNoteData.paying_date   = debitNote.paying_date;
                    debitNoteData.reference     = debitNote.reference;
                    debitNoteData.record_date   = debitNote.record_date;
                    debitNoteData.customer_name = debitNote.customer_name;
                    debitNoteData.billing_to    = debitNote.billing_to;
                    debitNoteData.cust_address  = debitNote.cust_address;
                    debitNoteData.customer_phone = debitNote.customer_phone;
                    debitNoteData.bl            = debitNote.bl;
                    debitNoteData.container_number = debitNote.container_number;
                    debitNoteData.commodity     = debitNote.commodity;
                    debitNoteData.package_number = debitNote.package_number;
                    debitNoteData.vessel        = debitNote.vessel;
                    debitNoteData.voy           = debitNote.voy;
                    debitNoteData.advance_money = debitNote.advance_money;

                    DebitNoteProduct.Debit_Note = debitNoteData;
                    DebitNoteProduct.DebitProductList = DebitProduct;

                    return View("Edit", DebitNoteProduct);
                }
            }
            
        }
        // GET: View user detail
        public ActionResult ViewDebitNote(int id = 0)
        {
            return RedirectToAction("AddEditViewDebit", "DebitNote", new { @id = id });
        }

        // GET: View user detail
        public ActionResult Create()
        {
            using (DoorEntities db = new DoorEntities())
            {
                DebitNoteModel debitNoteData = new DebitNoteModel();

                DebitNoteProductModel DebitNoteProduct = new DebitNoteProductModel();

                Debit_Note debit_last_data = getLastID();
                int id = debit_last_data.id + 1;
                string id_st = "No2018-" + id;
                debitNoteData.debit_fullId = id_st;

                DebitNoteProduct.Debit_Note = debitNoteData;
                DebitNoteProduct.DebitProductList = new List<Debit_Product>();

                return View("Create", DebitNoteProduct);
            }
            
        }
        [HttpPost]
        public ActionResult Create(DebitNoteProductModel debitProduct)
        {
            try
            {
                using (DoorEntities db = new DoorEntities())
                {
                    if (debitProduct.Debit_Note.id == 0)
                    {
                        Debit_Note usingData = this.convertDebit(debitProduct.Debit_Note, "create");
                        db.Debit_Note.Add(usingData);

                        db.SaveChanges();
                        return Json(new { success = true, message = "Save Successfully" }, JsonRequestBehavior.AllowGet);
        
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
            
        }
        public Debit_Note convertDebit(DebitNoteModel debitNote, string flag)
        {
            Debit_Note usingData = new Debit_Note();
            if (flag == "create")
            {
                usingData.debit_id = debitNote.debit_id;
                usingData.start_date = debitNote.start_date;
                usingData.end_date = debitNote.end_date;
                usingData.create_by = debitNote.create_by;
                usingData.create_on = debitNote.create_on;
                usingData.edit_by = debitNote.edit_by;
                usingData.paying_date = debitNote.paying_date;
                usingData.reference = debitNote.reference;
                usingData.record_date = debitNote.record_date;
                usingData.customer_name = debitNote.customer_name;
                usingData.billing_to = debitNote.billing_to;
                usingData.cust_address = debitNote.cust_address;
                usingData.customer_phone = debitNote.customer_phone;
                usingData.bl = debitNote.bl;
                usingData.container_number = debitNote.container_number;
                usingData.commodity = debitNote.commodity;
                usingData.package_number = debitNote.package_number;
                usingData.vessel = debitNote.vessel;
                usingData.voy = debitNote.voy;
                usingData.advance_money = debitNote.advance_money;

            }
            else
            {
                usingData.id = debitNote.id;
                usingData.debit_id = debitNote.debit_id;
                usingData.start_date = debitNote.start_date;
                usingData.end_date = debitNote.end_date;
                usingData.create_by = debitNote.create_by;
                usingData.create_on = debitNote.create_on;
                usingData.edit_by = debitNote.edit_by;
                usingData.paying_date = debitNote.paying_date;
                usingData.reference = debitNote.reference;
                usingData.record_date = debitNote.record_date;
                usingData.customer_name = debitNote.customer_name;
                usingData.billing_to = debitNote.billing_to;
                usingData.cust_address = debitNote.cust_address;
                usingData.customer_phone = debitNote.customer_phone;
                usingData.bl = debitNote.bl;
                usingData.container_number = debitNote.container_number;
                usingData.commodity = debitNote.commodity;
                usingData.package_number = debitNote.package_number;
                usingData.vessel = debitNote.vessel;
                usingData.voy = debitNote.voy;
                usingData.advance_money = debitNote.advance_money;

            }
            
            return usingData;
        }
        public DebitProductModel convertProduct(Debit_Product product)
        {
            DebitProductModel ProductData = new DebitProductModel();
            ProductData.product_id = product.product_id;
            ProductData.debit_id = (int)product.debit_id;
            ProductData.debit_full_id = (int)product.debit_full_id;
            ProductData.order_number = product.order_number;
            ProductData.edit_by = product.edit_by;
            ProductData.edit_on = product.edit_on;
            ProductData.product_name = product.product_name;
            ProductData.product_amount = product.product_amount;
            ProductData.product_amount_type = product.product_amount_type;
            ProductData.pro_unit_price = product.pro_unit_price;
            ProductData.total_price = product.total_price;
            ProductData.extra = product.extra;
            
            return ProductData;
        }
        
        public ActionResult AddEditDebitProduct(int productID)
        {
            DoorEntities db = new DoorEntities();
            DebitProductModel product = new DebitProductModel();
            if (productID > 0)
            {
                Debit_Product debit_product = db.Debit_Product.SingleOrDefault(x => x.product_id == productID);
                product = this.convertProduct(debit_product);
            }
            else
            {

            }
            return PartialView("product", product);
        }
        public Debit_Note getLastID()
        {
            using (DoorEntities db = new DoorEntities())
            {
                return db.Debit_Note.OrderByDescending(x => x.id).First(); //.FirstOrDefault<Debit_Note>();
            }
        }
        
	}
}