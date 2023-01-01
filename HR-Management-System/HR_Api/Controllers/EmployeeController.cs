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
            return Ok(EmployeeStatic.GetAllEmployee());
        }

        [HttpGet("{role}")]
        public IActionResult GetA(string role)
        {
            return Ok(EmployeeStatic.GetAEmployee);
        }

        [HttpPost]
        public IActionResult Insert(Employee employee)
        {
            return Ok(EmployeeStatic.InsertEmployee(employee));
        }

        [HttpPut("{role}")]
        public IActionResult Update(string role, Employee employee)
        {
            return Ok(EmployeeStatic.UpdateEmployee (role ,employee));
        }

        [HttpDelete("{role}")]
        public IActionResult Delete(string role)
        {
            return Ok(EmployeeStatic.DeleteDepartment(role));
        }
    }

    public static class EmployeeStatic
    {
        private static List<Employee> AllEmployee { get; set; } = new List<Employee>();

        public static Employee InsertEmployee(Employee employee)
        {
            AllEmployee.Add(employee);
            return employee;
        }

        public static List<Employee> GetAllEmployee()
        {
            return AllEmployee;
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
        {
            var employee = AllEmployee.FirstOrDefault(x => x.Role == role);
            AllEmployee = AllEmployee.Where(x => x.Role != employee.Role).ToList();
            return employee;
        }
    }

}

