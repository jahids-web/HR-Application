using DLL.EntityModel;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Api.Controllers
{
    
    public class HrAdminController : MainApiController
    {
        private readonly IHrAdminRepository _hrAdminRepository;

        public HrAdminController(IHrAdminRepository hrAdminRepository)
        {
            _hrAdminRepository = hrAdminRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _hrAdminRepository.GetAllAsync());
        }

        [HttpGet("{designation}")]
        public async Task<IActionResult> GetA(string designation)
        {
            return Ok(await _hrAdminRepository.GetAAsync(designation));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Employee employee)
        {
            return Ok(await _hrAdminRepository.InsertAsync(employee));
        }

        [HttpPut("{designation}")]
        public async Task<IActionResult> Update(string designation, Employee employee)
        {
            return Ok(await _hrAdminRepository.UpdateAsync(designation, employee));
        }

        [HttpDelete("{designation}")]
        public async Task<IActionResult> Delete(string designation)
        {
            return Ok(await _hrAdminRepository.DeleteAsync(designation));
        }
    }
}
