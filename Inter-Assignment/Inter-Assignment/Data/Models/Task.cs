﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inter_Assignment.Data.Models
{
    public class Task
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string DueDate { get; set; }

        public int? EmployeId { get; set; }

        [ForeignKey(nameof(EmployeId))]

        public Employee? Employee { get; set; }
    }
}