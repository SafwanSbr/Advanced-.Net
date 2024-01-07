namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Decorations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Costing = c.Int(nullable: false),
                        Colors = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 20),
                        EventDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        HallId = c.Int(),
                        DecorationId = c.Int(),
                        AdvanceAmount = c.Int(nullable: false),
                        TotalAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Decorations", t => t.DecorationId)
                .ForeignKey("dbo.Halls", t => t.HallId)
                .Index(t => t.HallId)
                .Index(t => t.DecorationId);
            
            CreateTable(
                "dbo.EventEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        Identity = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        TeamId = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Head = c.Int(),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Head)
                .Index(t => t.Head);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.MemberId)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.EventFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(),
                        FoodId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.FoodId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.FoodId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Costing = c.Int(nullable: false),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Details = c.String(),
                        Costing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "HallId", "dbo.Halls");
            DropForeignKey("dbo.EventFoods", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.EventFoods", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.EventEmployees", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.EventEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.TeamMembers", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.TeamMembers", "MemberId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Head", "dbo.Employees");
            DropForeignKey("dbo.Orders", "DecorationId", "dbo.Decorations");
            DropIndex("dbo.EventFoods", new[] { "FoodId" });
            DropIndex("dbo.EventFoods", new[] { "OrderId" });
            DropIndex("dbo.TeamMembers", new[] { "MemberId" });
            DropIndex("dbo.TeamMembers", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "Head" });
            DropIndex("dbo.Employees", new[] { "Team_Id" });
            DropIndex("dbo.Employees", new[] { "TeamId" });
            DropIndex("dbo.EventEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.EventEmployees", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "DecorationId" });
            DropIndex("dbo.Orders", new[] { "HallId" });
            DropTable("dbo.Halls");
            DropTable("dbo.Foods");
            DropTable("dbo.EventFoods");
            DropTable("dbo.TeamMembers");
            DropTable("dbo.Teams");
            DropTable("dbo.Employees");
            DropTable("dbo.EventEmployees");
            DropTable("dbo.Orders");
            DropTable("dbo.Decorations");
            DropTable("dbo.Admins");
        }
    }
}
