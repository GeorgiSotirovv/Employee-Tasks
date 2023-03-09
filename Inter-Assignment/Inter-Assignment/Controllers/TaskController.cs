using Microsoft.AspNetCore.Mvc;

namespace Inter_Assignment.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
