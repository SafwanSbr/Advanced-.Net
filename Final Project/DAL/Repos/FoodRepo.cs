using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FoodRepo : Repo, IRepo<Food, int, Food>
    {
        public Food Create(Food obj)
        {
            db.Foods.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Foods.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Food> Read()
        {
            return db.Foods.ToList();
        }

        public Food Read(int id)
        {
            return db.Foods.Find(id);
        }

        public Food Update(Food obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}