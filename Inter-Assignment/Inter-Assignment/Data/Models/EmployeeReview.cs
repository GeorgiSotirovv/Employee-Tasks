using System.ComponentModel.DataAnnotations;

namespace Inter_Assignment.Data.Models
{
    public class EmployeeReview
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string? Review { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }
}
