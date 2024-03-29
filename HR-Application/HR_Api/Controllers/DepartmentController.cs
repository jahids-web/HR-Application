﻿using BLL.Services;
using BLL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{

    public class DepartmentController : MainController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(DepartmentViewModel request)
        {
            return Ok(await _departmentService.InsertAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GatAll()
        {
            return Ok(await _departmentService.GetAllAsync());
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GatA(int departmentId)
        {
            return Ok(await _departmentService.GetAAsync(departmentId));
        }

        [HttpPut("{departmentId}")]
        public async Task<IActionResult> Update(int departmentId, DepartmentViewModel aDepartment)
        {
            return Ok(await _departmentService.UpdateAsync(departmentId, aDepartment));
        }

        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> Delete(int departmentId)
        {
            return Ok(await _departmentService.DeleteAsync(departmentId));
        }


    }
}
