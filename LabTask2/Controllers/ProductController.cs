using LabTask2.EntityFreamwork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask2.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductCatagory
        [HttpGet]
        public ActionResult ProductAdd() {
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product product) 
        {
            dotNetLabTask2Entities db = new dotNetLabTask2Entities();
            var data = db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        
        public ActionResult ProductDelete(int ID)
        {
            dotNetLabTask2Entities db = new dotNetLabTask2Entities();
            var data = db.Products.Find(ID);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductList()
        {
            dotNetLabTask2Entities db = new dotNetLabTask2Entities();
            var productList = db.Products.ToList();
            return View(productList);
        }
        [HttpGet]
        public ActionResult ProductEdit(int ID) {
            dotNetLabTask2Entities db = new dotNetLabTask2Entities();
            var aProduct = db.Products.Find(ID);
            return View(aProduct);
        }
        [HttpPost]
        public ActionResult ProductEdit(Product product)
        {
            dotNetLabTask2Entities db = new dotNetLabTask2Entities();
            var aProduct = db.Products.Find(product.ID);
            if(aProduct != null)
            {
                aProduct.Name = product.Name;
                aProduct.Price = product.Price;
                aProduct.CatagoryID = product.CatagoryID;
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }

            return View(aProduct);
        }
    }
}