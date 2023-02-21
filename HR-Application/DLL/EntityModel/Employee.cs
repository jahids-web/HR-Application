using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLL.EntityModel
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        //Department-Table
        public string DepartmentName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Designation { get; set; }

        public string Status { get; set; }

        public int TotalYearlyAllocatedleave { get; set; }

        public int MobileNo { get; set; }

        public string Leave { get; set; }

        public string IsEmployed { get; set; }

        public DateTime JoiningDate { get; set; }

        public DateTime DeparturedDate { get; set; }
        public int WorkHour { get; set; }
       
        public int DepartmentId { get; set; } //one employee one department one-one
  
        public Department Department { get; set; }

    }
}
