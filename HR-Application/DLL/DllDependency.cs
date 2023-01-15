using DLL.DataContext;
using DLL.Repositories;
using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public static class DllDependency
    {
        public static void AllDependency(this IServiceCollection services)
        {
            services.AddScoped<IUnitofWork, ApplicationDbContext>();
            services.AddTransient<IHrAdminRepository, HrAdminRepository>();
        }
       

    }
}
