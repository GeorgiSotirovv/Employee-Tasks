﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inter_Assignment.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required]
        public double MonthlySalary { get; set; }

        [Required]
        public int NumberOfCompletedTasks { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]

        public IEnumerable<EmployeeReview> EmployeeReviews { get; set; } = new List<EmployeeReview>();

    }
}
