using Inter_Assignment.Data;
using Inter_Assignment.Data.Models;
using Inter_Assignment.Models.EmployeeModels;
using Inter_Assignment.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inter_Assignment.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext context;

        public EmployeeService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async System.Threading.Tasks.Task AddEmployeeAsync(EmployeeViewModel model)
        {
            var entity = new Employee()
            {
                Id = model.Id,
                FullName = model.FullName,
                Emial = model.Emial,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                MonthlySalary = model.MonthlySalary
            };
            await context.Employees.AddAsync(entity);
            await context.SaveChangesAsync();
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
            employee.DateOfBirth = targetEmployee.DateOfBirth;
            employee.Emial = targetEmployee.Emial;
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
                    Emial = m.Emial,
                    PhoneNumber = m.PhoneNumber,
                    DateOfBirth = m.DateOfBirth,
                    MonthlySalary = m.MonthlySalary
                });
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
    }
}
