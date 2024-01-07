namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Xml.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.HarmonyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.HarmonyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                context.Halls.AddOrUpdate(new Models.Hall
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 5),
                    Location = Guid.NewGuid().ToString().Substring(0, 5),
                    Email = i + "hall@gmail.com",
                    Details = Guid.NewGuid().ToString(),
                    Costing = random.Next(100, 1000),
                });
            }
            for (int i = 1; i <= 10; i++)
            {
                context.Decorations.AddOrUpdate(new Models.Decoration
                {
                    Id = i,
                    Name = "Decoration" + i,
                    Email = "Decoration" + i + "@gmail.com",
                    Costing = random.Next(1, 11),
                    Colors = Guid.NewGuid().ToString().Substring(0, 15)
                });
            }
            for (int i = 1; i <= 10; i++)
            {
                context.Foods.AddOrUpdate(new Models.Food
                {
                    Id = i,
                    Name = "Food" + i,
                    Costing = random.Next(1, 11),
                    Details = Guid.NewGuid().ToString(),
                });
            }
            for (int i = 1; i <= 5; i++)
            {
                context.Admins.AddOrUpdate(new Models.Admin
                {
                    Id = i,
                    Name = "Admin" + i,
                    Password = Guid.NewGuid().ToString().Substring(10),
                    Email = "admin" + i + "@gmail.com",
                });
            }

            for (int i = 1; i <= 5; i++)
            {
                context.Orders.AddOrUpdate(new Models.Order
                {
                    Id = i,
                    CustomerName = Guid.NewGuid().ToString().Substring(0, 5),
                    EventDate = DateTime.Now,
                    Status = "Confirmed",
                    HallId = random.Next(1, 5),
                    DecorationId = random.Next(1, 5),
                    AdvanceAmount = 1000000,
                    TotalAmount = 1000000,
                });
            }
            for (int i = 1; i <= 5; i++)
            {
                context.Employees.AddOrUpdate(new Models.Employee
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 5),
                    Email = "employee" + i + "@gmail.com",
                    Password = Guid.NewGuid().ToString().Substring(10),
                    Identity = "Head Waiter",
                    Salary = random.Next(9000, 10000),
                    TeamId = random.Next(1, 5),
                });
            }
            for (int i = 1; i <= 5; i++)
            {
                context.TeamsMember.AddOrUpdate(new Models.Team
                {
                    Id = i,
                    Status = (i < 3) ? "Active" : "Inactive",
                });
            }
            for (int i = 1; i <= 5; i++)
            {
                context.EventEmployees.AddOrUpdate(new Models.EventEmployee
                {
                    Id = i,
                    OrderId = random.Next(1, 5),
                    EmployeeId = random.Next(1, 5),
                });
            }
            for (int i = 1; i <= 5; i++)
            {
                context.TeamMembers.AddOrUpdate(new Models.TeamMember
                {
                    Id = i,
                    TeamId = random.Next(1, 5),
                });
            }
            for (int i = 1; i <= 5; i++)
            {
                context.EventFoods.AddOrUpdate(new Models.EventFood
                {
                    Id = i,
                    OrderId = random.Next(1, 5),
                    FoodId = random.Next(1, 5),
                });
            }
        }
    }
}