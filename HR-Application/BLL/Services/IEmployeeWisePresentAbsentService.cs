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
    public interface IEmployeeWisePresentAbsentService
    {
        Task<EmployeeWisePresentAbsent> InsertAsync(EmployeeWisePresentAbsentViewModel request);
        Task<List<EmployeeWisePresentAbsent>> GetAllAsync();
        Task<EmployeeWisePresentAbsent> GetAAsync(string employeeWisePresentAbsentId);
        Task<EmployeeWisePresentAbsent> UpdateAsync(string employeeWisePresentAbsentId, EmployeeWisePresentAbsentViewModel requestData);
        Task<EmployeeWisePresentAbsent> DalateAsync(string employeeWisePresentAbsentId);
    }

    public class EmployeeWisePresentAbsentService : IEmployeeWisePresentAbsentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeWisePresentAbsentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeWisePresentAbsent> InsertAsync(EmployeeWisePresentAbsentViewModel request)
        {
            var employee =
            await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.EmployeeId == request.EmployeeId);

            EmployeeWisePresentAbsent data = new EmployeeWisePresentAbsent();
            data.EmployeeWisePresentAbsentId = request.EmployeeWisePresentAbsentId;
            data.Name = request.Name;
            data.EmployeeId = request.EmployeeId;
            data.Date = request.Date;
            data.IsPresent = request.IsPresent;
            data.DepartureTime = request.DepartureTime;
            data.EmployeeId = employee;

            try
            {
                await _unitOfWork.EmployeeWisePresentAbsentRepository.CreateAsync(data);

                if(await _unitOfWork.SaveChangesAsync())
                {
                    return data;
                }
            }
            catch (Exception ex) 
            {
                throw new ApplicationValidationException("Insert Has Some Problem");
            }
            return data;

        }

        public async Task<EmployeeWisePresentAbsent> GetAAsync(string employeeWisePresentAbsentId)
        {
            var employeReport = await _unitOfWork.EmployeeWisePresentAbsentRepository.FindSingLeAsync(x => x.EmployeeWisePresentAbsentId == employeeWisePresentAbsentId);
            if (employeReport == null)
            {
                throw new ApplicationValidationException("Data Not Found");
            }

            return employeReport;
        }

        public async Task<List<EmployeeWisePresentAbsent>> GetAllAsync()
        {
            return await _unitOfWork.EmployeeWisePresentAbsentRepository.GetList();
        }

        public async Task<EmployeeWisePresentAbsent> UpdateAsync(string employeeWisePresentAbsentId, EmployeeWisePresentAbsentViewModel requestData)
        {
            var data = await _unitOfWork.EmployeeWisePresentAbsentRepository.FindSingLeAsync(x => x.EmployeeWisePresentAbsentId == employeeWisePresentAbsentId);
            if(data == null)
            {
                throw new AccessViolationException("Data Not Found");
            }
            data.EmployeeWisePresentAbsentId = requestData.EmployeeWisePresentAbsentId;
            data.Name = requestData.Name;
            data.EmployeeId = requestData.EmployeeId;
            data.Date = requestData.Date;
            data.IsPresent = requestData.IsPresent;

            _unitOfWork.EmployeeWisePresentAbsentRepository.Update(data);
            if(await _unitOfWork.SaveChangesAsync())
            {
                return data;
            }
            throw new ApplicationValidationException("Update Has Some Problem");
        }

        public async Task<EmployeeWisePresentAbsent> DalateAsync(string employeeWisePresentAbsentId)
        {
            var employeReport = await _unitOfWork.EmployeeWisePresentAbsentRepository.FindSingLeAsync(x => x.EmployeeWisePresentAbsentId == employeeWisePresentAbsentId);

            if(employeReport == null)
            {
                throw new ApplicationValidationException("Data Not Found");
            }

            _unitOfWork.EmployeeWisePresentAbsentRepository.Delete(employeReport);
            if(await _unitOfWork.SaveChangesAsync())
            {
                return employeReport;     
            }
            throw new ApplicationValidationException("Employe Not Found");
        }
    }
}
