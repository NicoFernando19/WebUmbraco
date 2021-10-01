using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UmbracoAssignment.CustomDatabase.Entities;

namespace UmbracoAssignment.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public DateTime DoB { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public Department department { get; set; }
    }

}