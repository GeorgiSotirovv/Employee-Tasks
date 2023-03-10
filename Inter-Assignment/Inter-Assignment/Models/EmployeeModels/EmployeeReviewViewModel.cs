﻿using Inter_Assignment.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Inter_Assignment.Models.EmployeeModels
{
    public class EmployeeReviewViewModel
    {
        public int Id { get; set; }

        public int EmployeId { get; set; }

        public string Review { get; set; }

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}