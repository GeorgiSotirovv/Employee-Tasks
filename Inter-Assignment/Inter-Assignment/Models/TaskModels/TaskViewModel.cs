using Inter_Assignment.Data.Models;

namespace Inter_Assignment.Models.TaskModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string DueDate { get; set; }

        public int? EmployeId { get; set; }

        public IEnumerable<Employee> Employee { get; set; } = new List<Employee>();
    }
}
