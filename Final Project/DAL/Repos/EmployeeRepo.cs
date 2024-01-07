using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace DAL.Repos
{
    internal class EmployeeRepo : Repo, IRepo<Employee, int?, Employee>
    {
        public Employee Create(Employee emp)
        {
            db.Employees.Add(emp);
            if (db.SaveChanges() > 0) return emp;
            else return null;
        }
        public List<Employee> Read()
        {
            var employees = db.Employees.ToList();
            return employees;
        }
        public Employee Read(int? id)
        {
            var emp = db.Employees.Find(id);
            if(emp == null) return null;
            else return emp;
        }
        public bool Delete(int? id)
        {
            var emp = Read(id);
            if(emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                return true;
            }
            else return false;

        }
        public Employee Update(Employee emp)
        {
            var dbemp = Read(emp.Id);
            if(dbemp != null)
            {
                dbemp.Name = emp.Name;
                dbemp.Email = emp.Email;
                dbemp.Password = emp.Password;
                dbemp.Identity = emp.Identity;
                dbemp.Salary = emp.Salary;
                dbemp.TeamId = emp.TeamId;
                db.SaveChanges();
            }
            return dbemp;
        }
    }
}
