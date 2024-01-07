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
    internal class DecorationRepo : Repo, IRepo<Decoration, int, bool>
    {
        public bool Create(Decoration obj)
        {
            db.Decorations.Add(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Decorations.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Decoration> Read()
        {
            return db.Decorations.ToList();
        }

        public Decoration Read(int id)
        {
            return db.Decorations.Find(id);
        }

        public bool Update(Decoration obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true; else return false;
        }
    }
}
