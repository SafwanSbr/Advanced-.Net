using LabTask3.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask3.Controllers
{
    public class AdminController : Controller
    {
        //-----------------    Order   -----------------------------------
        public ActionResult OrderList()
        {
            dotNetLabTask3Entities1 db = new dotNetLabTask3Entities1();

            var list = db.Orders.ToList();
            return View(list);
        }
        public ActionResult OrderEdit(int id)
        {
            dotNetLabTask3Entities1 db = new dotNetLabTask3Entities1();
            var dbOrder = db.Orders.Find(id);
            dbOrder.Status = "Confirmed";
            db.SaveChanges();
            return RedirectToAction("OrderList");
        }

        //----------------------     Product  ------------------------
        public ActionResult ProductList() 
        {
            dotNetLabTask3Entities1 db = new dotNetLabTask3Entities1();

            var list = db.Products.ToList();
            return View(list);
        }
        public ActionResult ProductDelete(int id)
        {
            dotNetLabTask3Entities1 db = new dotNetLabTask3Entities1();
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            
            dotNetLabTask3Entities1 db = new dotNetLabTask3Entities1();
            var product = db.Products.Find(id);
            ViewBag.Category = db.Categories;
            return View(product);
            //return View();
        }
        [HttpPost]
        public ActionResult ProductEdit(Product product)
        {
            dotNetLabTask3Entities1 db = new dotNetLabTask3Entities1();
            var dbProduct = db.Products.Find(product.ID);
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Quantity = product.Quantity;
            dbProduct.Category_ID = product.Category_ID;
            db.SaveChanges();
            return RedirectToAction("ProductList");
            
        }

        //-----------------     User       --------------------------------
        public ActionResult UserList() {
            dotNetLabTask3Entities1 db = new dotNetLabTask3Entities1();
            var list = db.Users.ToList();
            return View(list);
        }

        //------------------  Category  -----------------------------------
        public ActionResult CategoryList() { 
            var db = new dotNetLabTask3Entities1();
            ViewBag.Cat = db.Categories.ToList();
            return View();
        }
    }
}