using DLL.EntityModel;
using DLL.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace DLL.DataContext
{
    public class ApplicationDbContext : DbContext, IUnitofWork
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public Task SaveChangesAsync()
        {
            return this.SaveChangesAsync();
        }

    }
}
