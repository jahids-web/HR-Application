using DLL.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace DLL.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalarys { get; set; }
        public DbSet<EmployeeWisePresentAbsent> EmployeeWisePresentAbsents { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
    }
}
