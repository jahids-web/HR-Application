using DLL.DataContext;
using DLL.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> InsertAsync(Employee employee); 
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetAAsync(int employeeId);
        Task<Employee> UpdateAsync(int employeeId, Employee employee);
        Task<Employee> DeleteAsync(int employeeId);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> InsertAsync(Employee employee)
        {
           await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetAAsync(int employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            return employee;
        }

        public async Task<Employee> UpdateAsync(int employeeId, Employee employee)
        {
            var findEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            findEmployee.EmployeeId = employee.EmployeeId;
            findEmployee.Name = employee.Name;
            findEmployee.Email = employee.Email;
            findEmployee.Status = employee.Status;
            findEmployee.WorkHour = employee.WorkHour;
            _context.Employees.Update(findEmployee);
            await _context.SaveChangesAsync();  
            return employee;
        }

        public async Task<Employee> DeleteAsync(int employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
