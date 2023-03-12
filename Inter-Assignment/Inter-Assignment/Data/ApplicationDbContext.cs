
using Inter_Assignment.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Inter_Assignment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }

        public DbSet<EmployeeReview> EmployeeReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.Task>()
                .HasKey(x => new { x.Id });

            //This is the seed data for database
            builder
                .Entity<Employee>()
                .HasData(new Employee()
                {
                    Id = 1,
                    FullName = "Ivan Davidov",
                    Email = "IvanDaviod@Gmail.com",
                    PhoneNumber = "089453164",
                    DateOfBirth = DateTime.ParseExact("2000-04-05", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    //DateOfBirth = DateTime.ParseExact("15/06/2015", "dd/MM/yyyy", null),
                    MonthlySalary = 2800
                },

                new Employee()
                {
                    Id = 2,
                    FullName = "Emil Yardanov",
                    Email = "EmilYardanov@Gmail.com",
                    PhoneNumber = "0897866941",
                    DateOfBirth = DateTime.ParseExact("2001-02-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    MonthlySalary = 1700
                },

                new Employee()
                {
                    Id = 3,
                    FullName = "Borislav Petrov",
                    Email = "BorislavBetrov@Gmail.com",
                    PhoneNumber = "089666387",
                    DateOfBirth = DateTime.ParseExact("1955-11-26", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    MonthlySalary = 5000
                },

                new Employee()
                {
                    Id = 4,
                    FullName = "David Batovski",
                    Email = "DavidBatovski@Gmail.com",
                    PhoneNumber = "0897847519",
                    DateOfBirth = DateTime.ParseExact("2022-08-08", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    MonthlySalary = 3500,
                    NumberOfCompletedTasks = 1
                });

            builder
                .Entity<Models.Task>()
                .HasData(new Models.Task()
                {
                    Id = 1,
                    Title = "Clean the computers",
                    Description = "You need to clean the computers from the dust",
                    DueDate = DateTime.ParseExact("2023-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    //DueDate = new DateTime(2000, 2, 15),
                    EmployeId = 1,
                    IsCompleted = false
                },

                new Models.Task()
                {
                    Id = 2,
                    Title = "Clean the peripheral devices",
                    Description = "Clean the peripheral devices for all computers from the dust",
                    DueDate = DateTime.ParseExact("2023-02-11", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EmployeId = 2,
                    IsCompleted = false
                },

                new Models.Task()
                {
                    Id = 3,
                    Title = "Check the fuses",
                    Description = "Check the fuses for all rooms and flors",
                    DueDate = DateTime.ParseExact("2023-03-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EmployeId = 3,
                    IsCompleted = false
                },

                new Models.Task()
                {
                    Id = 4,
                    Title = "Update all computers",
                    Description = "Update all computers's windows",
                    DueDate = DateTime.ParseExact("2012-03-05", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EmployeId = 4,
                    IsCompleted = true
                });

            base.OnModelCreating(builder);
        }
    }
}