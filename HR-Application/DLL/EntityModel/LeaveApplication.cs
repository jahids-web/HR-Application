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
    public class LeaveApplication
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string LeaveApplicationId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string DepartmentName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Subject { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Body { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string Status { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string From { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string To { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public DateTime ApprovalDate { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public DateTime ApplicationDate { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string LastUpdatedAt { get; set; }
        public Department Department { get; set; }
        public string EmployeeId { get; set; }
     
        public Employee Employee { get; set; } /*one-to-one*/
    }
}
