using BLL.Services;
using BLL.ViewModel;
using FluentAssertions.Execution;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using static BLL.ViewModel.EmployeeViewModel;

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
