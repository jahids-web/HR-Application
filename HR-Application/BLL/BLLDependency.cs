using BLL.Services;
using BLL.ViewModel;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public class BLLDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();

            AllFluentValidationDependency(services);
        }

        public static void AllFluentValidationDependency(IServiceCollection services)
        {
            services.AddScoped<IValidator<EmployeeViewModel>, EmployeeViewModelValidator>();
        }
    }
}
