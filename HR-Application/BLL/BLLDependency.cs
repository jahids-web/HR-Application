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
            services.AddTransient<IDepartmentService, DepartmentService>();

            AllFluentValidationDependency(services);
        }

        public static void AllFluentValidationDependency(IServiceCollection services)
        {
            services.AddScoped<IValidator<EmployeeViewModel>, EmployeeViewModelValidator>();
            services.AddScoped<IValidator<DepartmentViewModel>, DepartmentViewModelValidator>();
        }
    }
}
