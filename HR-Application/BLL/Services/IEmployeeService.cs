using BLL.ViewModel;
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
        Task<Employee> InsertAsync(EmployeeViewModel request);
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
        public async Task<Employee> InsertAsync(EmployeeViewModel request)
        {
            Employee aEmployee = new Employee();
            aEmployee.Name = request.Name;
            aEmployee.Email = request.Email;
            aEmployee.Status = request.Status;   
            aEmployee.Role = request.Role;
            aEmployee.Designation = request.Designation;
            aEmployee.MobileNo = request.MobileNo;
            aEmployee.WorkHour = request.WorkHour;
            return await _employeeRepository.InsertAsync(aEmployee);
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
