using Inter_Assignment.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Inter_Assignment.Models.EmployeeModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Emial { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        [Required]
        public double MonthlySalary { get; set; }

        public int NumberOfCompletedTasks { get; set; }

        public IEnumerable<EmployeeReview> EmployeeReviews { get; set; } = new List<EmployeeReview>();
    }
}