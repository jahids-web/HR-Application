using DLL.EntityModel;
using DLL.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1{version:apiVersion}/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("get all data");
        }

        [HttpGet("{department}")]
        public IActionResult GetA(string department)
        {
            return Ok("Get One + designation + data");
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return Ok("insert + department + data");
        }

        [HttpPut("{department}")]
        public IActionResult Update(string department)
        {
            return Ok("Update + department + data ");
        }

        [HttpDelete("{department}")]
        public IActionResult Delete(string department)
        {
            return Ok("delete + department + data");
        }
    }

}

public static class EmployeeController
{
    private static List<Employee> AllEmployee { get; set; } = new List<Employee>();

    public static Employee InsertEmployee (Employee employee)
    {
        AllEmployee.Add(employee);
        return employee;
    }

    public static Employee GetAEmployee(string role)
    {
        return AllEmployee.FirstOrDefault(x => x.Role == role);
    }

    public static Employee UpdateEmployee(string role, Employee employee)
    {
        foreach (var aEmployee in AllEmployee)
        {
            if (role == aEmployee.Role)
            {
                aEmployee.Name = employee.Name;
            }
           
        }
        return employee;
    }

    public static Employee DeleteDepartment(string role)
}