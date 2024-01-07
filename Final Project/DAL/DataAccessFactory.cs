using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Employee, int?, Employee> EmployeeData()
        {
            return new EmployeeRepo();
        }
        public static IRepo<EventEmployee, int, EventEmployee> EventEmployeeData()
        {
            return new EventEmployeeRepo();
        }
        public static IRepo<TeamMember, int, TeamMember> TeamMemberData()
        {
            return new TeamMemberRepo();
        }
        public static IRepo<Team, int?, Team> TeamData()
        {
            return new TeamRepo();
        }
        public static IRepo<Hall, int, bool> HallData()
        {
            return new HallRepo();
        }
        public static IRepo<Decoration, int, bool> DecorationData()
        {
            return new DecorationRepo();
        }
        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }
        public static IRepo<Admin, int, Admin> AdminData()
        {
            return new AdminRepo();
        }

        public static IRepo<Food, int, Food> FoodData()
        {
            return new FoodRepo();
        }

        public static IRepo<EventFood, int, EventFood> EventFoodData()
        {
            return new EventFoodRepo();
        }
    }
}
