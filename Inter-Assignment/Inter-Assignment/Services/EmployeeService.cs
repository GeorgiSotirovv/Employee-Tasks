using Inter_Assignment.Data;
using Inter_Assignment.Data.Models;
using Inter_Assignment.Models.EmployeeModels;
using Inter_Assignment.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Inter_Assignment.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext context;

        public EmployeeService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            return await context.Employees.ToListAsync();
        }

        public async System.Threading.Tasks.Task AddEmployeeAsync(EmployeeViewModel model)
        {
            var entity = new Employee()
            {
                Id = model.Id,
                FullName = model.FullName,
                Email = model.Emial,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                MonthlySalary = model.MonthlySalary
            };
            await context.Employees.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public EmployeeReviewViewModel AddReview(EmployeeReviewViewModel model)
        {
            var entity = new EmployeeReview()
            {
                EmployeeId = model.EmployeId,
                Review = model.Review,
            };

            context.EmployeeReviews.Add(entity);
            context.SaveChanges();

            return model;
        }

        public void EditEmployeeInformation(EmployeeViewModel targetEmployee)
        {
            var employee = context.Employees.
                Where(u => u.Id == targetEmployee.Id)
                .FirstOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Employee");
            }

            employee.FullName = targetEmployee.FullName;
            employee.Email = targetEmployee.Emial;
            employee.PhoneNumber = targetEmployee.PhoneNumber;
            employee.MonthlySalary = targetEmployee.MonthlySalary;

            context.SaveChanges();
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync()
        {
            var employees = await context.Employees
               .ToListAsync();

            return employees
                .Select(m => new EmployeeViewModel()
                {
                    Id = m.Id,
                    FullName = m.FullName,
                    Emial = m.Email,
                    PhoneNumber = m.PhoneNumber,
                    DateOfBirth = m.DateOfBirth,
                    MonthlySalary = m.MonthlySalary
                });
        }


        public async Task<IEnumerable<Employee>> GetFiveEmployeeWithMostComplitedTasks()
        {
            //need an improvement
            return await context.Employees
                .OrderByDescending(b => b.NumberOfCompletedTasks)
                .Take(5)
                .ToListAsync();
        }

        public async Task<EmployeeViewModel> GetInformationForEmployee(int empoyeeId)
        {
            var employee = await context.Employees
                .Where(u => u.Id == empoyeeId)
                .FirstOrDefaultAsync();


            var result = new EmployeeViewModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Emial = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                MonthlySalary = employee.MonthlySalary
            };

            return result;
        }

        public async System.Threading.Tasks.Task RemoveEmployeeFromDatabaseAsync(int Id)
        {
            var employee = await context.Employees
                .Where(u => u.Id == Id)
                .FirstOrDefaultAsync();


            if (employee == null)
            {
                throw new ArgumentException("Invalid Employee");
            }

            context.Employees.Remove(employee);

            await context.SaveChangesAsync();
        }

        public async Task<EmployeeReviewViewModel> GetReviewsAsync(int empId)
        {
            var employee = await context.Employees
              .Where(u => u.Id == empId)
              .Include(m => m.EmployeeReviews)
              .FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new ArgumentException("Invalid ashtray Id");
            }

            return new EmployeeReviewViewModel()
            {
                EmployeeReviews = employee.EmployeeReviews,
                EmployeId = employee.EmployeeId
            };
        }
    }
}