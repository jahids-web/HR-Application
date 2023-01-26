using BLL.Services;
using BLL.ViewModel;
using DLL.EntityModel;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{
    public class EmployeeController : MainController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert (EmployeeViewModel request)
        {
            return Ok(await _employeeService.InsertAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GatAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GatA(int employeeId)
        {
            return Ok(await _employeeService.GetAAsync(employeeId));
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(int employeeId, Employee employee)
        {
            return Ok(await _employeeService.UpdateAsync(employeeId, employee));
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            return Ok (await _employeeService.DeleteAsync(employeeId));
        }
    }
}
