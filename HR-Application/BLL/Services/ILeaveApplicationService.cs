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
        Task<LeaveApplication> UpdateAsync(string leaveApplicationId, LeaveApplicationViewModel requestData);
        Task<LeaveApplication> DeleteAsync(string leaveApplicationId);
    }

    public class LeaveApplicationService : ILeaveApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaveApplicationService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        public Task<LeaveApplication> InsertAsync(LeaveApplicationViewModel viewEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveApplication> GetAAsync(string leaveApplicationId)
        {
            var leave = await _unitOfWork.LeaveApplicationRepository.FindSingLeAsync(x => x.LeaveApplicationId== leaveApplicationId);
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

        public Task<LeaveApplication> UpdateAsync(string leaveApplicationId, LeaveApplicationViewModel requestData)
        {
            throw new NotImplementedException();
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
