using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class HarmonyContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> TeamsMember { get; set; }//
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<EventEmployee> EventEmployees { get; set; }
        public DbSet<EventFood> EventFoods { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Food> Foods { get; set; }

    }
}