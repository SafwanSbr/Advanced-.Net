using MidAssignment.EntityFramework;
using MidAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidAssignment.Controllers
{
    public class ResturantController : Controller
    {
        // GET: Resturant
        //-----------------------------------  Request  -----------------------------------------------
        public ActionResult MyRequestList()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            var db = new dotNet_MidAssignmentEntities();
            var list = db.Requests.Where(x => x.ResturantID == (int)Session["userID"]);
            return View(db.Requests.ToList());
        }

        
        public ActionResult AddRequest()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            var db = new dotNet_MidAssignmentEntities();

            Request request = new Request()
            {
                RequestTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Status = "Pending",
                ResturantID = (int)Session["userID"]
            };
            db.Requests.Add(request);
            db.SaveChanges();

            var checkRequest = db.Requests.FirstOrDefault(x => x.RequestTime == request.RequestTime);

            if (checkRequest != null)
            {
                return RedirectToAction("ItemsInRequest",  new { id = checkRequest.ID } );
            }

            return View();
        }
        public ActionResult ItemsInRequest(int id)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            var db = new dotNet_MidAssignmentEntities();
            var items = db.Items.Where(x => x.RequestID == id).ToList();
            ViewBag.reqID = id;
            return View(items);
        }

        [HttpGet]
        public ActionResult AddItem(int id)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            var db = new dotNet_MidAssignmentEntities();
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddItem(ItemDTO tempItem)
        {
            var db = new dotNet_MidAssignmentEntities();
            Item item = new Item()
            {
                Name = tempItem.Name,
                ExpireDate = tempItem.ExpireDate.ToString("yyyy-MM-dd"),
                Quantity = tempItem.Quantity,
                RequestID = tempItem.RequestID,
            };
            db.Items.Add(item);
            db.SaveChanges();

            return RedirectToAction("ItemsInRequest", new { id =item.RequestID });
        }
        public ActionResult DeleteItem(int id)
        {
            var db = new dotNet_MidAssignmentEntities();
            var item = db.Items.Find(id);
            int reqID = (int)item.RequestID;
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("ItemsInRequest", new { id = reqID});
        }
        public ActionResult LogOut ()
        {
            Session.Clear();
            return RedirectToAction("LogIn", "Home");
        }
    }
}