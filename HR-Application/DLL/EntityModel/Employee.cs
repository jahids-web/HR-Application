using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLL.EntityModel
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Role { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Designation { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        public string Status { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        public int MobileNo { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        public int WorkHour { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        public int EarlyLeft { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        public int OverTime { get; set; }

     

    }
}
