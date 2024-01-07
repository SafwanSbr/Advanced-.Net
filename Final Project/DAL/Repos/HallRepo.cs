using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class HallRepo : Repo, IRepo<Hall, int, bool>
    {
        public bool Create(Hall obj)
        {
            db.Halls.Add(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Halls.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Hall> Read()
        {
            return db.Halls.ToList();
        }

        public Hall Read(int id)
        {
            return db.Halls.Find(id);
        }

        public bool Update(Hall obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) { return true; }
            else { return false; }
        }
    }
}