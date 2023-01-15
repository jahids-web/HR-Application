using DLL.DataContext;
using DLL.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IHrAdminRepository
    {
        Task<Employee> InsertAsync(Employee employeeId);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetAAsync(int employeeId);
        Task<Employee> UpdateAsync(int employeeId, Employee employee);
        Task<Employee> DeleteAsync(int employeeId);
    }

    public class HrAdminRepository : IHrAdminRepository
    {
        private readonly IUnitofWork _context;

        public HrAdminRepository(IUnitofWork context)
        {
            _context = context;  
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employee.AsQueryable().ToListAsync();
        }

        public async Task<Employee> InsertAsync(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteAsync(int employeeId)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(a => a.EmployeeId == employeeId);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetAAsync(int employeeId)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(a => a.EmployeeId == employeeId);
            return employee;
        }

        public async Task<Employee> UpdateAsync(int employeeId, Employee employee)
        {
            var findEmployee = await _context.Employee.FirstOrDefaultAsync(a => a.EmployeeId == employeeId);

            findEmployee.Name = employee.Name;
            findEmployee.Email = employee.Email;
            findEmployee.Designation = employee.Designation;
            findEmployee.Present = employee.Present;
            findEmployee.LeaveReport = employee.LeaveReport;
            _context.Employee.Update(findEmployee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
