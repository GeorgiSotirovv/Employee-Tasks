using Inter_Assignment.Models.EmployeeModels;
using Inter_Assignment.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using static Inter_Assignment.WebConstants;

namespace Inter_Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _EmployeeService)
        {
            employeeService = _EmployeeService;
        }

        //This Action display all Employees
        [HttpGet]
        public async Task<IActionResult> Employees()
        {

            var model = await employeeService.GetAllEmployeesAsync();

            return View(model);
        }

        //This Action load the view of AddEmployee
        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            return View();
        }

        //This Action add the newly created employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel model)
        {
            try
            {
                await employeeService.AddEmployeeAsync(model);

                return RedirectToAction(nameof(Employees));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", "Something went wrong");

                TempData[GlobalExeptionError] = "You forgot to fill some field please try again";

                return View(model);
            }
        }

        //This Action remove Employee
        public async Task<IActionResult> RemoveEmployee(int employeeId)
        {
            await employeeService.RemoveEmployeeFromDatabaseAsync(employeeId);

            return RedirectToAction(nameof(Employees));
        }

        //This Action recive Id of the employee and load the model with the information for the employee
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

        //This Action edit the employeee
        [HttpPost]
        public IActionResult EditEmployee(int Id, EmployeeViewModel targetEmployee)
        {
            try
            {
                employeeService.EditEmployeeInformation(targetEmployee);

                return RedirectToAction(nameof(Employees));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                TempData[GlobalExeptionError] = "You forgot to fill some field please try again";

                return View(targetEmployee);
            }
        }

        //This Action show five empolyees with most compleeted tasks for last mounth
        [HttpGet]
        public async Task<IActionResult> EmployeStatistic()
        {
            var targetEmployee = await employeeService.GetFiveEmployeeWithMostComplitedTasks();

            return View(targetEmployee);
        }

        //This Action load the view AddAction
        [HttpGet]
        public async Task<IActionResult> AddReview()
        {

            var model = new EmployeeReviewViewModel()
            {
                Employees = await employeeService.GetEmployeeAsync()
            };

            return View(model);
        }

        //This action add review to employee
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

                TempData[GlobalExeptionError] = "You forgot to fill some field please try again";

                return RedirectToAction(nameof(AddReview));
            }
        }

        //This Action recive Id of an employee and with it add review to the employee 
        [HttpGet]
        public async Task<IActionResult> Review(int Id)
        {
            var model = employeeService.GetReviewsAsync(Id).Result;
            return View(model);
        }

    }
}
