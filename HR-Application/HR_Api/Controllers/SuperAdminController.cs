using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{
    public class SuperAdminController : MainController
    {
        private readonly IEmployeeService _employeeService;

        public SuperAdminController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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
    }
}
