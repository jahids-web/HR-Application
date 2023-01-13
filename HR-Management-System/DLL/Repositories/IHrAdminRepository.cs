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
        Task<Employee> InsertAsync(Employee designation);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetAAsync(string designation);
        Task<Employee> UpdateAsync(string designation, Employee employee);
        Task<Employee> DeleteAsync(string designation);
    }

    public class HrAdminRepository : IHrAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public HrAdminRepository(ApplicationDbContext context)
        {
            _context = context;  
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> InsertAsync(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteAsync(string designation)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(a => a.Designation == designation);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetAAsync(string designation)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(a => a.Designation == designation);
            return employee;
        }

        public async Task<Employee> UpdateAsync(string designation, Employee employee)
        {
            var findEmployee = await _context.Employee.FirstOrDefaultAsync(a => a.Designation == designation);

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
