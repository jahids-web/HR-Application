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
    public class Employee_Wise_Present_Absent
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public DateTime Date { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public int IsPresent { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public int DepartureTime { get; set; }
    }
}
