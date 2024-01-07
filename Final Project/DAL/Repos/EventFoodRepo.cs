using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EventFoodRepo : Repo, IRepo<EventFood, int, EventFood>
    {
        public EventFood Create(EventFood obj)
        {
            db.EventFoods.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.EventFoods.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<EventFood> Read()
        {
            return db.EventFoods.ToList();
        }

        public EventFood Read(int id)
        {
            return db.EventFoods.Find(id);
        }

        public EventFood Update(EventFood obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}