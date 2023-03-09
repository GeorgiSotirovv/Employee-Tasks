using System.ComponentModel.DataAnnotations;

namespace Inter_Assignment.Data.Models
{
    public class Employee
    {
        //FullName
        //Emial 
        //Phone
        //DateOfBirth
        //MonthlySalary
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Emial { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string DateOfBirth { get; set; } = null!;

        [Required]
        public double MonthlySalary { get; set; }
    }
}
