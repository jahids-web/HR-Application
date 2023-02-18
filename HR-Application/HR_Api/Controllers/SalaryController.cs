using BLL.Services;
using BLL.ViewModel;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{
    public class SalaryController : MainController
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(SalaryViewModel request)
        {
            return Ok(await _salaryService.InsertAsync(request));
        }

        [HttpGet("employeSalaryId")]
        public async Task<IActionResult> GetA(string employeeSalaryId)
        {
            return Ok(await _salaryService.GetAAsync(employeeSalaryId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok (await _salaryService.GetAllAsync());     
        }

        [HttpPut("employeeSalaryId")]
        public async Task<IActionResult> Update(string employeeSalaryId, SalaryViewModel requestData)
        {
            return Ok(await _salaryService.UpdateAsync(employeeSalaryId, requestData));
        }

        [HttpDelete("employeSalaryId")]
        public async Task<IActionResult> Delete(string employeeSalaryId)
        {
            return Ok(await _salaryService.DeleteAsync(employeeSalaryId));  
        }
    }
}
