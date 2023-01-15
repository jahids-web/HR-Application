using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLL.EntityModels
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? DepartmentName { get; set; }
    }
}
