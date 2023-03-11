using Inter_Assignment.Models.EmployeeModels;
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

        [HttpGet]
        public async Task<IActionResult> Employees()
        {

            var model = await employeeService.GetAllEmployeesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel model)
        {
            try
            {
                await employeeService.AddEmployeeAsync(model);

                return RedirectToAction(nameof(Employees));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> RemoveEmployee(int employeeId)
        {
            await employeeService.RemoveEmployeeFromDatabaseAsync(employeeId);

            return RedirectToAction(nameof(Employees));
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int Id)
        {
            var targetEmployee = await employeeService.GetInformationForEmployee(Id);

            var model = new EmployeeViewModel()
            {
                Id = Id,
                FullName = targetEmployee.FullName,
                Emial = targetEmployee.Emial,
                PhoneNumber = targetEmployee.PhoneNumber,
                MonthlySalary = targetEmployee.MonthlySalary
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult EditEmployee(int Id, EmployeeViewModel targetEmployee)
        {
            if (targetEmployee == null)
            {
                return View();
            }

            try
            {
                employeeService.EditEmployeeInformation(targetEmployee);

                return RedirectToAction(nameof(Employees));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(targetEmployee);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EmployeStatistic()
        {
            var targetEmployee = await employeeService.GetFiveEmployeeWithMostComplitedTasks();

            return View(targetEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> AddReview()
        {

            var model = new EmployeeReviewViewModel()
            {
                Employees = await employeeService.GetEmployeeAsync()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddReview(EmployeeReviewViewModel model)
        {
            try
            {
                employeeService.AddReview(model);

                return RedirectToAction(nameof(Employees));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return RedirectToAction(nameof(AddReview));
            }
        }


        [HttpGet]
        public async Task<IActionResult> Review(int Id)
        {
            var model = employeeService.GetReviewsAsync(Id).Result;
            return View(model);
        }

    }
}
