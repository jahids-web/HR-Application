using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ISalaryRepository SalaryRepository { get; }
        ILeaveApplicationRepository LeaveApplicationRepository { get; }
        IEmployeeWisePresentAbsentRepository EmployeeWisePresentAbsentRepository { get; }
        Task<bool> SaveChangesAsync();
        
    }
}
