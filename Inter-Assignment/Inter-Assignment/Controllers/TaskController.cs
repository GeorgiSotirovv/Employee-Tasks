using Inter_Assignment.Models.TaskModels;
using Inter_Assignment.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Inter_Assignment.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService _TaskService)
        {
            taskService = _TaskService;
        }

        [HttpGet]
        public async Task<IActionResult> Task()
        {

            var model = await taskService.GetAllTasksAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskViewModel model)
        {
            try
            {
                await taskService.AddTasksAsync(model);

                return RedirectToAction(nameof(Task));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> RemoveTask(int employeeId)
        {
            await taskService.RemoveTaskFromDatabaseAsync(employeeId);

            return RedirectToAction(nameof(Task));
        }
    }
}
