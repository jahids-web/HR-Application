using BLL.ViewModel;
using DLL.EntityModel;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Exceptions;

namespace BLL.Services
{
    public interface IEmployeeService
    {
        Task<Employee> InsertAsync(EmployeeViewModel request);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetAAsync(int employeeId);
        Task<Employee> UpdateAsync(int employeeId, EmployeeViewModel aemployee);
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

            await _employeeRepository.CreateAsync(aEmployee);

            if(await _employeeRepository.SaveCompletedAsync())
            {
                return aEmployee;
            }
            throw new ApplicationValidationException("Employe Insert Has Some Problem");
        }

        public async Task<Employee> GetAAsync(int employeeId)
        {
            var employee = await _employeeRepository.FindSingLeAsync(x => x.EmployeeId == employeeId);
            if (employee == null)
            {
                throw new ApplicationValidationException("Employee Not Found");
            }
            return employee;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetList();
        }

        public async Task<Employee> UpdateAsync(int employeeId, EmployeeViewModel aemployee)
        {
           var employee = await _employeeRepository.FindSingLeAsync(x => x.EmployeeId == employeeId);
            if(employee == null)
            {
                throw new ApplicationValidationException("Employe Not Found");
            }
            if (!string.IsNullOrWhiteSpace(aemployee.Name))
            {
                var existsAlreasy = await _employeeRepository.FindSingLeAsync(x => x.Name == aemployee.Name);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                employee.Name = aemployee.Name;
            }

            if (!string.IsNullOrWhiteSpace(aemployee.Email))
            {
                var existsAlreasy = await _employeeRepository.FindSingLeAsync(x => x.Email == aemployee.Email);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                employee.Email = aemployee.Name;
            }

            if (!string.IsNullOrWhiteSpace(aemployee.Designation))
            {
                var existsAlreasy = await _employeeRepository.FindSingLeAsync(x => x.Designation == aemployee.Designation);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                employee.Designation = aemployee.Designation;
            }

            if (!string.IsNullOrWhiteSpace(aemployee.Status))
            {
                var existsAlreasy = await _employeeRepository.FindSingLeAsync(x => x.Status == aemployee.Status);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                employee.Status = aemployee.Status;
            }

            if (!string.IsNullOrWhiteSpace(aemployee.WorkHour))
            {
                var existsAlreasy = await _employeeRepository.FindSingLeAsync(x => x.WorkHour == aemployee.WorkHour);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                employee.WorkHour = aemployee.WorkHour;
            }
            
            _employeeRepository.Update(employee);
            if (await _employeeRepository.SaveCompletedAsync())
            {
                return employee;
            }
            throw new ApplicationValidationException("In Update have Some Problem");
        }

        public async Task<Employee> DeleteAsync(int employeeId)
        {
           var employee = await _employeeRepository.FindSingLeAsync(x => x.EmployeeId == employeeId);
            if (employee == null)
            {
                throw new ApplicationValidationException("Employe Not Found");
            }

            _employeeRepository.Delete(employee);

            if (await _employeeRepository.SaveCompletedAsync())
            {
                return employee;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
        }

    }
}
