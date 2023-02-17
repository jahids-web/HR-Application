using BLL.Services;
using BLL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{
    public class AdminController : MainController
    {
        private readonly IEmployeeService _employeeService;

        public AdminController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(EmployeeViewModel request)
        {
            return Ok(await _employeeService.InsertAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GatAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GatA(string employeeId)
        {
            return Ok(await _employeeService.GetAAsync(employeeId));
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(string employeeId, EmployeeViewModel aemployee)
        {
            return Ok(await _employeeService.UpdateAsync(employeeId, aemployee));
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> Delete(string employeeId)
        {
            return Ok(await _employeeService.DeleteAsync(employeeId));
        }
    }
}
