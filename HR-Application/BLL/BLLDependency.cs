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
            services.AddTransient<ISalaryService, SalaryService>();
            services.AddTransient<ILeaveApplicationService, LeaveApplicationService>();
            services.AddTransient<ILeaveApplicationService, LeaveApplicationService>();
            services.AddTransient<IEmployeeWisePresentAbsentService, EmployeeWisePresentAbsentService>();

            AllFluentValidationDependency(services);
        }

        public static void AllFluentValidationDependency(IServiceCollection services)
        {
            services.AddScoped<IValidator<EmployeeViewModel>, EmployeeViewModelValidator>();
            services.AddScoped<IValidator<DepartmentViewModel>, DepartmentViewModelValidator>();
            services.AddScoped<IValidator<SalaryViewModel>, SalaryViewModelValidator>();
            services.AddScoped<IValidator<LeaveApplicationViewModel>, LeaveApplicationViewModelValidator>();
            services.AddScoped<IValidator<EmployeeWisePresentAbsentViewModel>, EmployeeWisePresentAbsentViewModelValidator>();
        }
    }
}
