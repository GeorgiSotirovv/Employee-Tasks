using Inter_Assignment.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Inter_Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _EmployeeService)
        {
            employeeService = _EmployeeService;
        }

        public async Task<IActionResult> Employees()
        {

            var model = await employeeService.GetAllEmployeesAsync();

            return View(model);
        }
    }
}
