using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        Task<bool> SaveChangesAsync();
        
    }
}
