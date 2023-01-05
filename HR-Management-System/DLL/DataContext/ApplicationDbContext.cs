using DLL.EntityModel;
using DLL.EntityModels;
using Microsoft.EntityFrameworkCore;


namespace DLL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
