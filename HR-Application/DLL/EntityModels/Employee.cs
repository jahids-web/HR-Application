using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLL.EntityModel
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string? Email { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Role { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string? Designation { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string? MobileNo { get; set; }

        public DateTime Present { get; set; } = DateTime.Now;
        public DateTime LeaveReport { get; set; } = DateTime.Now;
    }
}
 