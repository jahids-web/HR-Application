using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityModel
{
    public class EmployeeSalary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeSalaryId { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string PostedAt { get; set; }
        public string PostedBy { get; set; }
        public string IsProvided { get; set; }
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }// one to one 
        public Department Department { get; set; }// one to one 
    }
}
