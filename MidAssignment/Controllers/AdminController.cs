using MidAssignment.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidAssignment.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        //--------------------------------  Employee Handelling ---------------------------------------
        public ActionResult RequestList()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            var db = new dotNet_MidAssignmentEntities();
            return View(db.Requests.ToList());
        }
        [HttpGet]
        public ActionResult AssignEmployee(int id)
        {
            var db = new dotNet_MidAssignmentEntities();
            var req = db.Requests.Find(id);
            ViewBag.EmployeeID = db.Employees.ToList();
            return View(req);

            //return RedirectToAction("RequestList");
        }
        [HttpPost]
        public ActionResult AssignEmployee(Request request)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            var db = new dotNet_MidAssignmentEntities();
            var req = db.Requests.Find(request.ID);
            req.EmployeeID = request.EmployeeID;
            req.Status = "Picking Up";

            db.SaveChanges();
            return RedirectToAction("RequestList");
        }

        //------------------------------------  Log Out -----------------------------------------------
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("LogIn", "Home");
        }
    }
}