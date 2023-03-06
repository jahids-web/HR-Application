using BLL.ViewModel;
using DLL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ILeaveApplicationService
    {
        Task<LeaveApplication> InsertAsync(LeaveApplicationViewModel viewEntity);
        Task<List<LeaveApplication>> GetAllAsync();
        Task<LeaveApplication> GetAAsync(string LeaveApplicationId);
        Task<LeaveApplication> UpdateAsync(string LeaveApplicationId, LeaveApplicationViewModel requestData);
        Task<LeaveApplication> DeleteAsync(string LeaveApplicationId);
    }

    public class LeaveApplicationService : ILeaveApplicationService
    {
        public Task<LeaveApplication> InsertAsync(LeaveApplicationViewModel viewEntity)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveApplication> GetAAsync(string LeaveApplicationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveApplication>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveApplication> UpdateAsync(string LeaveApplicationId, LeaveApplicationViewModel requestData)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveApplication> DeleteAsync(string LeaveApplicationId)
        {
            throw new NotImplementedException();
        }

    }
}
