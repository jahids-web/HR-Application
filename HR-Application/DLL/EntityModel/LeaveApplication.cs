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
        public string LeaveApplicationId { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string LastUpdatedAt { get; set; }
        public Department Department { get; set; }
        public string EmployeeId { get; set; }
     
        public Employee Employee { get; set; } /*one-to-one*/
    }
}
