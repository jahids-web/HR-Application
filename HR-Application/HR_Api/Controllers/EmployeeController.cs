﻿using BLL.Services;
using BLL.ViewModel;
using DLL.EntityModel;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utility.Exceptions;

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
        public async Task<IActionResult> EmployeRequestInsertAsync(EmployeeViewModel request)
        {
            return Ok(await _employeeService.InsertAsync(request));
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GatA(int employeeId)
        {
            return Ok(await _employeeService.GetAAsync(employeeId));
        }

      
    }
}
