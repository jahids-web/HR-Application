using DLL.DataContext;
using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public class DllDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("HrDatabase")));


            //Repository Depandency
            //services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            //services.AddTransient<IStudentRepository, StudentRepository>();
            //services.AddTransient<ICourseRepository, CourseRepository>();

            //services.AddTransient<IUnitOfWork.IUnitOfWork, UnitOfWork>();


        }
    }
}
