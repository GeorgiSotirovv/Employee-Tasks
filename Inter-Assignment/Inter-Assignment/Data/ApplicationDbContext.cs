using Inter_Assignment.Data.Configuration;
using Inter_Assignment.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
                    Emial = "IvanDaviod@Gmail.com",
                    PhoneNumber = "089453164",
                    DateOfBirth = "05/05/2000",
                    MonthlySalary = 2800
                },

                new Employee()
                {
                    Id = 2,
                    FullName = "Emil Yardanov",
                    Emial = "EmilYardanov@Gmail.com",
                    PhoneNumber = "0897866941",
                    DateOfBirth = "11/12/2001",
                    MonthlySalary = 1700
                },

                new Employee()
                {
                    Id = 3,
                    FullName = "Borislav Betrov",
                    Emial = "BorislavBetrov@Gmail.com",
                    PhoneNumber = "089666387",
                    DateOfBirth = "05/05/2000",
                    MonthlySalary = 5000
                },

                new Employee()
                {
                    Id = 4,
                    FullName = "David Batovski",
                    Emial = "DavidBatovski@Gmail.com",
                    PhoneNumber = "0897847519",
                    DateOfBirth = "07/01/1995",
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
                    EmployeId = 1
                },

                new Models.Task()
                {
                    Id = 2,
                    Title = "Clean the peripheral devices",
                    Description = "Clean the peripheral devices for all computers from the dust",
                    DueDate = "01/04/2022",
                    EmployeId = 2
                },

                new Models.Task()
                {
                    Id = 3,
                    Title = "Check the fuses",
                    Description = "Check the fuses for all rooms and flors",
                    DueDate = "01/04/2022",
                    EmployeId = 3
                },

                new Models.Task()
                {
                    Id = 4,
                    Title = "Update all computers",
                    Description = "Update all computers's windows",
                    DueDate = "01/04/2022",
                    EmployeId = 4
                });

            base.OnModelCreating(builder);
        }
    }
}