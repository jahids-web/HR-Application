using DLL.EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1{version:apiVersion}/[controller]")]
    public class HrAdminController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(EmployeeStatic.GetAllEmployee());
        }

        [HttpGet("{employeId}")]
        public IActionResult GetA(string employeId)
        {
            return Ok(EmployeeStatic.GetAEmployee);
        }

        [HttpPost]
        public IActionResult Insert(Employee employee)
        {
            return Ok(EmployeeStatic.InsertEmployee(employee));
        }

        [HttpPut("{employeId}")]
        public IActionResult Update(string employeId, Employee employee)
        {
            return Ok(EmployeeStatic.UpdateEmployee(employeId, employee));
        }

        [HttpDelete("{employeId}")]
        public IActionResult Delete(string employeId)
        {
            return Ok(EmployeeStatic.DeleteDepartment(employeId));
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

        public static Employee GetAEmployee(int employeeId)
        {
            return AllEmployee.FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public static Employee UpdateEmployee(int employeeId, Employee employee)
        {
            foreach (var aEmployee in AllEmployee)
            {
                if (employeeId == aEmployee.EmployeeId)
                {
                    aEmployee.Name = employee.Name;
                }

            }
            return employee;
        }

        public static Employee DeleteDepartment(int employeeId)
        {
            var employee = AllEmployee.FirstOrDefault(x => x.EmployeeId == employeeId);
            AllEmployee = AllEmployee.Where(x => x.EmployeeId != employee.EmployeeId).ToList();
            return employee;
        }
    }
}
