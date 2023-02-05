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
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Employee> InsertAsync(EmployeeViewModel request)
        {
            Employee aEmployee = new Employee();
            aEmployee.Name = request.Name;
            aEmployee.Email = request.Email;
            aEmployee.Status = request.Status;   
            aEmployee.Role = request.Role;
            aEmployee.Designation = request.Designation;
            aEmployee.TotalYearlyAllocatedleave = request.TotalYearlyAllocatedleave;
            aEmployee.Leave = request.Leave;
            aEmployee.IsEmployed = request.IsEmployed;
            aEmployee.JoiningDate = request.JoiningDate;
            aEmployee.DeparturedDate = request.DeparturedDate;
            aEmployee.MobileNo = request.MobileNo;
            aEmployee.WorkHour = request.WorkHour;

            await _unitOfWork.EmployeeRepository.CreateAsync(aEmployee);

            if(await _unitOfWork.SaveChangesAsync())
            {
                return aEmployee;
            }
            throw new ApplicationValidationException("Employe Insert Has Some Problem");
        }
        
        public async Task<Employee> GetAAsync(int employeeId)
        {
            var employee = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.EmployeeId == employeeId);
            if (employee == null)
            {
                throw new ApplicationValidationException("Employee Not Found");
            }
            return employee;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _unitOfWork.EmployeeRepository.GetList();
        }

        public async Task<Employee> UpdateAsync(int employeeId, EmployeeViewModel requestData)
        {
           var employee = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.EmployeeId == employeeId);
            if(employee == null)
            {
                throw new ApplicationValidationException("Employe Not Found");
            }
            if (!string.IsNullOrWhiteSpace(requestData.Name))
            {
                var existsAlreasy = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.Name == requestData.Name);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                employee.Name = requestData.Name;
            }

            if (!string.IsNullOrWhiteSpace(requestData.Email))
            {
                var existsAlreasy = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.Email == requestData.Email);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Email alrady present in our systam");
                }
                employee.Email = requestData.Name;
            }

            if (string.IsNullOrWhiteSpace(requestData.Designation))
            {
                var existsAlreasy = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.Designation == requestData.Designation);
                employee.Designation = requestData.Designation;
            }

            if (!string.IsNullOrWhiteSpace(requestData.Status))
            {
                var existsAlreasy = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.Status == requestData.Status);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Status alrady present in our systam");
                }
                employee.Status = requestData.Status;
            }

            if (requestData.TotalYearlyAllocatedleave < 0)
            {
                var existsAlreasy = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.TotalYearlyAllocatedleave == requestData.TotalYearlyAllocatedleave);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Status alrady present in our systam");
                }
                employee.TotalYearlyAllocatedleave = requestData.TotalYearlyAllocatedleave;
            }

            if (!string.IsNullOrWhiteSpace(requestData.Leave))
            {
                var existsAlreasy = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.Leave == requestData.Leave);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated WorkHour alrady present in our systam");
                }
                employee.Leave = requestData.Leave;
            }

            if (!string.IsNullOrWhiteSpace(requestData.IsEmployed))
            {
                var existsAlreasy = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.IsEmployed == requestData.IsEmployed);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated WorkHour alrady present in our systam");
                }
                employee.IsEmployed  = requestData.IsEmployed;
            }

            if (requestData.WorkHour < 0)
            {
                var existsAlreasy = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.WorkHour == requestData.WorkHour);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated WorkHour alrady present in our systam");
                }
                employee.WorkHour = requestData.WorkHour;
            }

            _unitOfWork.EmployeeRepository.Update(employee);
            if (await _unitOfWork.SaveChangesAsync())
            {
                return employee;
            }
            throw new ApplicationValidationException("In Update have Some Problem");
        }

        public async Task<Employee> DeleteAsync(int employeeId)
        {
           var employee = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.EmployeeId == employeeId);
            if (employee == null)
            {
                throw new ApplicationValidationException("Employe Not Found");
            }

            _unitOfWork.EmployeeRepository.Delete(employee);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return employee;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
        }

     
    }
}
