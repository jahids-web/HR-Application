using BLL.Services;
using BLL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{
    public class LeaveApplicationController : MainController
    {
        private readonly ILeaveApplicationService _leaveApplicationService;

        public LeaveApplicationController(ILeaveApplicationService leaveApplicationService) 
        {
            _leaveApplicationService = leaveApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(LeaveApplicationViewModel request)
        {
            var result = await _leaveApplicationService.InsertAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _leaveApplicationService.GetAllAsync());
        }

        [HttpGet("{leaveApplicationId}")]
        public async Task<IActionResult> GatA(string leaveApplicationId)
        {
            return Ok(await _leaveApplicationService.GetAAsync(leaveApplicationId));
        }

        [HttpPut("{leaveApplicationId}")]
        public async Task<IActionResult> Update(string leaveApplicationId, LeaveApplicationViewModel leaveRequest)
        {
            return Ok(await _leaveApplicationService.UpdateAsync(leaveApplicationId, leaveRequest));
        }

        [HttpDelete("{leaveApplicationId}")]
        public async Task<IActionResult>Delete(string leaveApplicationId)
        {
            return Ok(await _leaveApplicationService.DeleteAsync(leaveApplicationId));
        }
    }
}
