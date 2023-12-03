using LabTask3.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask3.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        public ActionResult Product() {
            dotNetLabTask3Entities1 db = new dotNetLabTask3Entities1();
            var list = db.Products.ToList();
            return View(list);
        }
        public ActionResult Orders()
        {
            return View();
        }
    }
}