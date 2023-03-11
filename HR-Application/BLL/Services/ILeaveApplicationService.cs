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
    public interface ILeaveApplicationService
    {
        Task<LeaveApplication> InsertAsync(LeaveApplicationViewModel viewEntity);
        Task<List<LeaveApplication>> GetAllAsync();
        Task<LeaveApplication> GetAAsync(string leaveApplicationId);
        Task<LeaveApplication> UpdateAsync(string leaveApplicationId, LeaveApplicationViewModel leaveRequest);
        Task<LeaveApplication> DeleteAsync(string leaveApplicationId);
    }

    public class LeaveApplicationService : ILeaveApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaveApplicationService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        public async Task<LeaveApplication> InsertAsync(LeaveApplicationViewModel viewEntity)
        {
            var department =
              await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.DepartmentName == viewEntity.DepartmentName);
            var employee =
              await _unitOfWork.EmployeeRepository.FindSingLeAsync(x => x.EmployeeId == viewEntity.EmployeeId);

            LeaveApplication leaveData = new LeaveApplication();
            leaveData.LeaveApplicationId = viewEntity.LeaveApplicationId;
            leaveData.Name = viewEntity.Name;
            leaveData.EmployeeId = viewEntity.EmployeeId;
            leaveData.DepartmentName = viewEntity.DepartmentName;
            leaveData.Subject = viewEntity.Subject;
            leaveData.Body = viewEntity.Body;
            leaveData.Status = viewEntity.Status;
            leaveData.From = viewEntity.From;
            leaveData.To = viewEntity.To;
            leaveData.ApplicationDate = viewEntity.ApplicationDate;
            leaveData.ApprovalDate = viewEntity.ApprovalDate;
            leaveData.LastUpdatedAt = viewEntity.LastUpdatedAt;

            try
            {
                await _unitOfWork.LeaveApplicationRepository.CreateAsync(leaveData);

                if (await _unitOfWork.SaveChangesAsync())
                {
                    return leaveData;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationValidationException("Insert Has Some Problem");
            }
            return leaveData;
        }

        public async Task<LeaveApplication> GetAAsync(string leaveApplicationId)
        {
            var leave = await _unitOfWork.LeaveApplicationRepository.FindSingLeAsync(x => x.LeaveApplicationId == leaveApplicationId);
            if(leave == null)
            {
                throw new ApplicationValidationException("LeaveApp Not Found");
            }  
            return leave;
        }

        public async Task<List<LeaveApplication>> GetAllAsync()
        {
            return await _unitOfWork.LeaveApplicationRepository.GetList();
        }

        public async Task<LeaveApplication> UpdateAsync(string leaveApplicationId, LeaveApplicationViewModel requestData)
        {
            var leaveApplication = await _unitOfWork.LeaveApplicationRepository.FindSingLeAsync(x => x.LeaveApplicationId == leaveApplicationId);
            if (leaveApplicationId == null)
            {
                throw new ApplicationValidationException("Id Not Found");
            }

            leaveApplication.LeaveApplicationId = requestData.LeaveApplicationId;
            leaveApplication.Name = requestData.Name;
            leaveApplication.EmployeeId = requestData.EmployeeId;
            leaveApplication.DepartmentName = requestData.DepartmentName;
            leaveApplication.Subject = requestData.Subject;
            leaveApplication.Body = requestData.Body;
            leaveApplication.Status = requestData.Status;
            leaveApplication.From = requestData.From;
            leaveApplication.To = requestData.To;
            leaveApplication.ApplicationDate = requestData.ApplicationDate;
            leaveApplication.ApprovalDate = requestData.ApprovalDate;
            leaveApplication.LastUpdatedAt = requestData.LastUpdatedAt;

            _unitOfWork.LeaveApplicationRepository.Update(leaveApplication);
            if (await _unitOfWork.SaveChangesAsync())
            {
                return leaveApplication;
            }
            throw new ApplicationValidationException("Update Has Some Problem");
        }

        public async Task<LeaveApplication> DeleteAsync(string leaveApplicationId)
        {
            var leave = await _unitOfWork.LeaveApplicationRepository.FindSingLeAsync(x => x.LeaveApplicationId == leaveApplicationId);
            if (leave == null)
            {
                throw new ApplicationValidationException("LeaveApp lication Not Found");
            }

            _unitOfWork.LeaveApplicationRepository.Delete(leave);
            if (await _unitOfWork.SaveChangesAsync())
            {
                return leave;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
        }

    }
}
