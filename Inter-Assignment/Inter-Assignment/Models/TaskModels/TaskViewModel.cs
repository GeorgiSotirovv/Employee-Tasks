using Inter_Assignment.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Inter_Assignment.Models.TaskModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public DateTime DueDate { get; set; }

        [Required]
        public int? EmployeId { get; set; }

        public bool IsCompleted { get; set; }

        public Employee Employee { get; set; }

        public string EmployeeFullName { get; set; }

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
