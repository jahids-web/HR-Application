using DLL.EntityModel;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{
    public class EmployeeController : MainController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Insert (Employee employee)
        {
            return Ok(await _employeeRepository.InsertAsync(employee));
        }

        [HttpGet]
        public async Task<IActionResult> GatAll()
        {
            return Ok(await _employeeRepository.GetAllAsync());
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GatA(int employeeId)
        {
            return Ok(await _employeeRepository.GetAAsync(employeeId));
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(int employeeId, Employee employee)
        {
            return Ok(await _employeeRepository.UpdateAsync(employeeId, employee));
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            return Ok (await _employeeRepository.DeleteAsync(employeeId));
        }
    }
}
