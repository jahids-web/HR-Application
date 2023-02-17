using DLL.DataContext;
using DLL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface ISalaryRepository : IRepositoryBase<EmployeeSalary>
    {

    }

    public class SalaryRepository : RepositoryBase<EmployeeSalary>, ISalaryRepository
    {
        public SalaryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
