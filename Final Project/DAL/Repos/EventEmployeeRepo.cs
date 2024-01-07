using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EventEmployeeRepo : Repo, IRepo<EventEmployee, int, EventEmployee>
    {
        public EventEmployee Create(EventEmployee eventEmployee)
        {
            if (eventEmployee != null)
            {
                db.EventEmployees.Add(eventEmployee);
                db.SaveChanges();
                return eventEmployee;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var eventEmployee = Read(id);
            if(eventEmployee==null) return false;
            db.EventEmployees.Remove(eventEmployee);
            db.SaveChanges();
            return true;
        }

        public List<EventEmployee> Read()
        {
            return db.EventEmployees.ToList();
        }

        public EventEmployee Read(int id)
        {
            var eventEmployee = db.EventEmployees.Find(id);
            return eventEmployee;
        }

        public EventEmployee Update(EventEmployee eventEmployee)
        {
            var dbeventEmployee = Read(eventEmployee.Id);
            if(dbeventEmployee==null) return null;

            dbeventEmployee.OrderId = eventEmployee.OrderId;
            dbeventEmployee.EmployeeId = eventEmployee.EmployeeId;
            db.SaveChanges();
            return dbeventEmployee;
        }
    }
}
