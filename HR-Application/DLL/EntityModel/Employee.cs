using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLL.EntityModel
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        //Department-Table
        

        [Column(TypeName = "nvarchar(50)")]
        public string DepartmentName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Role { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Designation { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string Status { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public int TotalYearlyAllocatedleave { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public int MobileNo { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string Leave { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string IsEmployed { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public DateTime JoiningDate { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public DateTime DeparturedDate { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public int WorkHour { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
