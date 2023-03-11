using DLL.DataContext;
using DLL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IEmployeeWisePresentAbsentRepository : IRepositoryBase<EmployeeWisePresentAbsent>
    {

    }

    public class EmployeeWisePresentAbsentRepository : RepositoryBase<EmployeeWisePresentAbsent>, IEmployeeWisePresentAbsentRepository
    {
        public EmployeeWisePresentAbsentRepository(ApplicationDbContext context) : base(context) 
        { 
        
        }
    }
}
