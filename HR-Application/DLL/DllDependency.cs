using DLL.DataContext;
using DLL.Repositories;
using DLL.UnitOfWork;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public class DllDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("HrDatabase")));


            //Repository Depandency
            //services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IUnitOfWork.IUnitOfWork, UnitOfWork>();


        }
    }
}
