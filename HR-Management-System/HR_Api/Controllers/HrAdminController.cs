using DLL.EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Api.Controllers
{
    
    public class HrAdminController : MainApiController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(EmployeeStatic.GetAllEmployee());
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetA(string employeId)
        {
            return Ok(EmployeeStatic.GetAEmployee);
        }

        [HttpPost]
        public IActionResult Insert(Employee employee)
        {
            return Ok(EmployeeStatic.InsertEmployee(employee));
        }

        [HttpPut("{employeeId}")]
        public IActionResult Update(int employeeId, Employee employee)
        {
            return Ok(EmployeeStatic.UpdateEmployee(employeeId, employee));
        }

        [HttpDelete("{employeeId}")]
        public IActionResult Delete(int employeeId)
        {
            return Ok(EmployeeStatic.DeleteDepartment(employeeId));
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
