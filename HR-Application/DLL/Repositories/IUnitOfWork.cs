using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        Task<bool> SaveChangesAsync();
        //Task<bool> SaveCompletedAsync();
    }
}
