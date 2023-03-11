using BLL.Services;
using BLL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{
    public class EmployeeWisePresentAbsentController : MainController
    {
        private readonly IEmployeeWisePresentAbsentService _employeeWisePresentAbsentService;
        public EmployeeWisePresentAbsentController(IEmployeeWisePresentAbsentService employeeWisePresentAbsentService) 
        {
            _employeeWisePresentAbsentService = employeeWisePresentAbsentService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(EmployeeWisePresentAbsentViewModel request)
        {
            var result = await _employeeWisePresentAbsentService.InsertAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeWisePresentAbsentService.GetAllAsync());
        }

        [HttpGet("{employeeWisePresentAbsentId}")]
        public async Task<IActionResult> GetA(string employeeWisePresentAbsentId)
        {
            return Ok(await _employeeWisePresentAbsentService.GetAAsync(employeeWisePresentAbsentId));
        }

        [HttpPut("{employeeWisePresentAbsentId}")]

        public async Task<IActionResult>Update(string employeeWisePresentAbsentId, EmployeeWisePresentAbsentViewModel requestData)
        {
            return Ok(await _employeeWisePresentAbsentService.UpdateAsync(employeeWisePresentAbsentId, requestData));
        }

        [HttpDelete("{employeeWisePresentAbsentId}")]
        public async Task<IActionResult>Delete(string employeeWisePresentAbsentId)
        {
            return Ok(await _employeeWisePresentAbsentService.DalateAsync(employeeWisePresentAbsentId));
        }

    }
}
