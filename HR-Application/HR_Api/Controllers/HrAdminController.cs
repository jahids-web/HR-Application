using DLL.EntityModel;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

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
            return Ok( await _hrAdminRepository.GetAllAsync());
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetA(int employeeId)
        {
            return Ok(await _hrAdminRepository.GetAAsync(employeeId));
        }


        [HttpPost]
        public async Task<IActionResult> Insert(Employee employee)
        {
            return Ok(await _hrAdminRepository.InsertAsync(employee));
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Update(int employeeId, Employee employee)
        {
            return Ok(await _hrAdminRepository.UpdateAsync(employeeId, employee));
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            return Ok(await _hrAdminRepository.DeleteAsync(employeeId));
        }
    }
}
