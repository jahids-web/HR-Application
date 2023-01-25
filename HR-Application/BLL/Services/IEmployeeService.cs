using DLL.EntityModel;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IEmployeeService
    {
        Task<Employee> InsertAsync(Employee employee);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetAAsync(int employeeId);
        Task<Employee> UpdateAsync(int employeeId, Employee employee);
        Task<Employee> DeleteAsync(int employeeId);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> InsertAsync(Employee employee)
        {
            return await _employeeRepository.InsertAsync(employee);
        }

        public async Task<Employee> GetAAsync(int employeeId)
        {
            return await _employeeRepository.GetAAsync(employeeId);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> UpdateAsync(int employeeId, Employee employee)
        {
            return await _employeeRepository.UpdateAsync(employeeId, employee);
        }

        public async Task<Employee> DeleteAsync(int employeeId)
        {
            return await _employeeRepository.DeleteAsync(employeeId);
        }

    }
}
