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
        Task<Employee> GetAAsync(string employeeId);
        Task<Employee> UpdateAsync(string employeeId, EmployeeViewModel requestData);
        Task<Employee> DeleteAsync(string employeeId);
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
            var department =
               await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.DepartmentId == request.DepartmentId);
            if (department == null)
            {
                
            }
            Employee aEmployee = new Employee();
            aEmployee.EmployeeId = request.EmployeeId;
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
            aEmployee.Department = department;
            aEmployee.DepartmentId = department.DepartmentId;
            await _unitOfWork.EmployeeRepository.CreateAsync(aEmployee);

            if(await _unitOfWork.SaveChangesAsync())
            {
                return aEmployee;
            }
            throw new ApplicationValidationException("Employe Insert Has Some Problem");
        }
        
        public async Task<Employee> GetAAsync(string employeeId)
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

        public async Task<Employee> UpdateAsync(string employeeId, EmployeeViewModel requestData)
        {
           var employee = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.EmployeeId == employeeId);
            if(employee == null)
            {
                throw new ApplicationValidationException("Employe Not Found");
            }
            if (!string.IsNullOrWhiteSpace(requestData.Name))
            {
                employee.Name = requestData.Name;
            }

            if (!string.IsNullOrWhiteSpace(requestData.Email))
            {
                var existsAlreasy = await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.Email == requestData.Email);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Email alrady present in our systam");
                }
                employee.Email = requestData.Email;
            }

            if (!string.IsNullOrWhiteSpace(requestData.Designation))
            {
                employee.Designation = requestData.Designation;
            }
            if (!string.IsNullOrWhiteSpace(requestData.Role))
            {
                employee.Role = requestData.Role;
            }
            if (!string.IsNullOrWhiteSpace(requestData.Status))
            {
                employee.Status = requestData.Status;
            }

            if (requestData.TotalYearlyAllocatedleave < 0)
            {
                employee.TotalYearlyAllocatedleave = requestData.TotalYearlyAllocatedleave;
            }
            employee.MobileNo = requestData.MobileNo;

            if (!string.IsNullOrWhiteSpace(requestData.Leave))
            {
                employee.Leave = requestData.Leave;
            }
            employee.JoiningDate= requestData.JoiningDate;
            employee.DeparturedDate= requestData.DeparturedDate;

            if (requestData.WorkHour > 0)
            { 
                employee.WorkHour = requestData.WorkHour;
            }

            _unitOfWork.EmployeeRepository.Update(employee);
            if (await _unitOfWork.SaveChangesAsync())
            {
                return employee;
            }
            throw new ApplicationValidationException("In Update have Some Problem");
        }

        public async Task<Employee> DeleteAsync(string employeeId)
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
