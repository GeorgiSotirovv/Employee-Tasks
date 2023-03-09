using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inter_Assignment.Data.Models
{
    public class Task
    {
        //Title
        //Description
        //Assignee
        //Due Date

        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime DueDate { get; set; }

        public int? EmployeId { get; set; }

        [ForeignKey(nameof(EmployeId))]

        public Employee? Employee { get; set; }
    }
}
