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
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Key]
        public int DepartmentId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string DepartmentName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Month { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public int Year { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string PostedAT { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string PostedBy { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string IsProvided { get; set; }
    }
}
