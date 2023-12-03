using AutoMapper;
using MidAssignment.EntityFramework;
using MidAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MidAssignment.Controllers
{
    public class HomeController : Controller
    {
        //----------------------------------------- Log In --------------------------------------------
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginValidation user)
        {
            var db = new dotNet_MidAssignmentEntities();
            if (user.UserType == "Admin")
            {
                var dbAdmin = db.Admins.FirstOrDefault(x => x.Email.Equals(user.Email));
                if(dbAdmin != null && dbAdmin.Password.Equals(user.Password))
                {
                    Session["userID"] = dbAdmin.ID;
                    return RedirectToAction("RequestList", "Admin");
                }
            }
            else if(user.UserType == "Resturant")
            {
                var dbResturant = db.Resturants.FirstOrDefault(x => x.Email.Equals(user.Email));
                if (dbResturant != null && dbResturant.Password.Equals(user.Password))
                {
                    Session["userID"] = dbResturant.ID;
                    return RedirectToAction("MyRequestList", "Resturant");
                }
            }
            else
            {
                var dbEmployee = db.Employees.FirstOrDefault(x => x.Email.Equals(user.Email));
                if (dbEmployee != null && dbEmployee.Password.Equals(user.Password))
                {
                    Session["userID"] = dbEmployee.ID;
                    return RedirectToAction("MyRequestList", "Employee");
                }
            }
            return View(user);
        }

        //-------------------------------------- Employee Registration ----------------------------------
        [HttpGet]
        public ActionResult EmployeeRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeRegistration(EmployeeDTO tempEmployee)
        {
            var db = new dotNet_MidAssignmentEntities();
            #region
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>(); 
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Employee>(tempEmployee);
            #endregion

            db.Employees.Add(data);
            db.SaveChanges();

            return RedirectToAction("Login");
        }

        //------------------------------------- Resturant Registration --------------------------------
        [HttpGet]
        public ActionResult ResturantRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResturantRegistration(ResturantDTO tempResturant)
        {
            var db = new dotNet_MidAssignmentEntities();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ResturantDTO, Resturant>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Resturant>(tempResturant);
            
            db.Resturants.Add(data);
            return RedirectToAction("Login");
        }
    }
}