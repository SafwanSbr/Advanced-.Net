using MidAssignment.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult MyRequestList()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            var db = new dotNet_MidAssignmentEntities();
            int userID = (int)Session["userID"];
            var list = db.Requests.Where(x => x.EmployeeID == userID).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult UpdateRequest(int id)
        {
            if (Session["userID"] == null) { return RedirectToAction("LogIn", "Home"); }

            var db = new dotNet_MidAssignmentEntities();
            var req = db.Requests.Find(id);
            req.CollectionTime = DateTime.Now.ToString("yyyy-MM-dd");
            req.Status = "Collection Done";
            
            db.SaveChanges();

            return RedirectToAction("MyRequestList");
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("LogIn", "Home");
        }
    }
}