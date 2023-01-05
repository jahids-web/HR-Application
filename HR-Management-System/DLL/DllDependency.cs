using DLL.DataContext;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public static class DllDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            //Connection Strings
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HrConnection"));
            });
            //  
        }

      
    }
}
