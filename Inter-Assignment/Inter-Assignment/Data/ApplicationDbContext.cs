
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

            builder
                .Entity<Employee>()
                .HasData(new Employee()
                {
                    Id = 1,
                    FullName = "Ivan Davidov",
                    Email = "IvanDaviod@Gmail.com",
                    PhoneNumber = "089453164",
                    DateOfBirth = "10",
                    //DateOfBirth = DateTime.ParseExact("09/01/2009", "d",CultureInfo.InvariantCulture),
                    MonthlySalary = 2800
                },

                new Employee()
                {
                    Id = 2,
                    FullName = "Emil Yardanov",
                    Email = "EmilYardanov@Gmail.com",
                    PhoneNumber = "0897866941",
                    DateOfBirth = "10",
                    MonthlySalary = 1700
                },

                new Employee()
                {
                    Id = 3,
                    FullName = "Borislav Betrov",
                    Email = "BorislavBetrov@Gmail.com",
                    PhoneNumber = "089666387",
                    DateOfBirth = "10",
                    MonthlySalary = 5000
                },

                new Employee()
                {
                    Id = 4,
                    FullName = "David Batovski",
                    Email = "DavidBatovski@Gmail.com",
                    PhoneNumber = "0897847519",
                    DateOfBirth = "10",
                    MonthlySalary = 3500
                });

            builder
                .Entity<Models.Task>()
                .HasData(new Models.Task()
                {
                    Id = 1,
                    Title = "Clean the computers",
                    Description = "You need to clean the computers from the dust",
                    DueDate = "01/04/2022",
                    EmployeId = 1,
                    IsCompleted = false
                },

                new Models.Task()
                {
                    Id = 2,
                    Title = "Clean the peripheral devices",
                    Description = "Clean the peripheral devices for all computers from the dust",
                    DueDate = "01/04/2022",
                    EmployeId = 2,
                    IsCompleted = false
                },

                new Models.Task()
                {
                    Id = 3,
                    Title = "Check the fuses",
                    Description = "Check the fuses for all rooms and flors",
                    DueDate = "01/04/2022",
                    EmployeId = 3,
                    IsCompleted = false
                },

                new Models.Task()
                {
                    Id = 4,
                    Title = "Update all computers",
                    Description = "Update all computers's windows",
                    DueDate = "01/04/2022",
                    EmployeId = 4,
                    IsCompleted = true
                });

            base.OnModelCreating(builder);
        }
    }
}