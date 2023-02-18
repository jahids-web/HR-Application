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
    public interface IDepartmentService
    {
        Task<Department> InsertAsync(DepartmentViewModel request);
        Task<List<Department>> GetAllAsync();
        Task<Department> GetAAsync(int departmentId);
        Task<Department> UpdateAsync(int departmentId, DepartmentViewModel aDepartment);
        Task<Department> DeleteAsync(int departmentId);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Department> InsertAsync(DepartmentViewModel request)
        {
            Department aDepartment = new Department();
            aDepartment.DepartmentId = request.DepartmentId;
            aDepartment.DepartmentName = request.DepartmentName;
 

            await _unitOfWork.DepartmentRepository.CreateAsync(aDepartment);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return aDepartment;
            }
            throw new ApplicationValidationException("Department Insert Has Some Problem");
        }

        public async Task<Department> GetAAsync(int departmentId)
        {
            var department = await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.DepartmentId == departmentId);
            if (department == null)
            {
                throw new ApplicationValidationException("Department Not Found");
            }
            return department;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _unitOfWork.DepartmentRepository.GetList();
        }

        public async Task<Department> UpdateAsync(int departmentId, DepartmentViewModel aDepartment)
        {
            var employee = await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.DepartmentId == departmentId);
            if (employee == null)
            {
                throw new ApplicationValidationException("Employe Not Found");
            }
            if (!string.IsNullOrWhiteSpace(aDepartment.DepartmentName))
            {
                var existsAlreasy = await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.DepartmentName == aDepartment.DepartmentName);
                if (existsAlreasy != null)
                {
                    throw new ApplicationValidationException("You updated Email alrady present in our systam");
                }
                employee.DepartmentName = aDepartment.DepartmentName;
            }

            _unitOfWork.DepartmentRepository.Update(employee);
            if (await _unitOfWork.SaveChangesAsync())
            {
                return employee;
            }
            throw new ApplicationValidationException("In Update have Some Problem");
        }

        public async Task<Department> DeleteAsync(int departmentId)
        {
            var department = await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.DepartmentId == departmentId);
            if (department == null)
            {
                throw new ApplicationValidationException("Department Not Found");
            }

            _unitOfWork.DepartmentRepository.Delete(department);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return department;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
        }
      
    }
}
