using BLL.ViewModel;
using DLL.EntityModel;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utility.Exceptions;

namespace BLL.Services
{
    public interface ISalaryService
    {
        Task<EmployeeSalary> InsertAsync(SalaryViewModel request);
        Task<List<EmployeeSalary>> GetAllAsync();
        Task<EmployeeSalary> GetAAsync(string employeeSalaryId);
        Task<EmployeeSalary> UpdateAsync(string employeeSalaryId, SalaryViewModel requestData);
        Task<EmployeeSalary> DeleteAsync(string employeeSalaryId);
    }

    public class SalaryService : ISalaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalaryService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        public async Task<EmployeeSalary> InsertAsync(SalaryViewModel request)
        {
            var department =
              await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.DepartmentName == request.DepartmentName);
            var employee =
              await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.EmployeeId == request.EmployeeId);

            EmployeeSalary salaryData = new EmployeeSalary();
            salaryData.EmployeeSalaryId = request.EmployeeSalaryId;
            salaryData.IsProvided = request.IsProvided;
            salaryData.Month = request.Month;
            salaryData.PostedAt = request.PostedAt;
            salaryData.PostedBy = request.PostedBy;
            salaryData.Name = request.Name;
            salaryData.Year = request.Year;
            salaryData.DepartmentName = request.DepartmentName;
            salaryData.EmployeeId = request.EmployeeId;
            salaryData.Department = department;
            salaryData.Employee = employee;

            await _unitOfWork.SalaryRepository.CreateAsync(salaryData);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return salaryData;
            }

            throw new ApplicationValidationException("Insert Has Some Problem");
        }

        public async Task<EmployeeSalary> GetAAsync(string employeeSalaryId)
        {
            var employeeSalary = await _unitOfWork.SalaryRepository.FindSingLeAsync(x => x.EmployeeSalaryId == employeeSalaryId);
            if (employeeSalary == null)
            {
                throw new ApplicationValidationException("Employee Not Found");
            }

            return employeeSalary;
        }

        public async Task<List<EmployeeSalary>> GetAllAsync()
        {
            return await _unitOfWork.SalaryRepository.GetList();
        }

        public async Task<EmployeeSalary> UpdateAsync(string employeeSalaryId, SalaryViewModel requestData)
        {
            var employeSalaryData = await _unitOfWork.SalaryRepository.FindSingLeAsync(x => x.EmployeeSalaryId == employeeSalaryId);
            if(employeeSalaryId == null)
            {
                throw new ApplicationValidationException("Employe Not Found");
            }
            employeSalaryData.Name = requestData.Name;
            employeSalaryData.DepartmentName = requestData.DepartmentName;
            employeSalaryData.PostedBy = requestData.PostedBy;
            employeSalaryData.PostedAt = requestData.PostedAt;
            employeSalaryData.Month = requestData.Month;
            employeSalaryData.Year = requestData.Year;
            employeSalaryData.IsProvided = requestData.IsProvided;
            employeSalaryData.EmployeeId = requestData.EmployeeId;

            _unitOfWork.SalaryRepository.Update(employeSalaryData);
            if (await _unitOfWork.SaveChangesAsync())
            {
                return employeSalaryData;
            }
            throw new ApplicationValidationException("Update Has Some Problem");
        }

        public async Task<EmployeeSalary> DeleteAsync(string employeeSalaryId)
        {
            var employeSalary = await _unitOfWork.SalaryRepository.FindSingLeAsync(x => x.EmployeeSalaryId == employeeSalaryId);
            if (employeSalary == null)
            {
                throw new ApplicationValidationException("Employe Not Found");
            }

            _unitOfWork.SalaryRepository.Delete(employeSalary);

            if(await _unitOfWork.SaveChangesAsync())
            {
                return employeSalary;
            }
            throw new ApplicationValidationException("Delete Has Some Problem");
        }
        
    }
}
