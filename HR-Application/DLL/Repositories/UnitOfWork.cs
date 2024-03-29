﻿using System;
using System.Threading.Tasks;
using DLL.DataContext;

namespace DLL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly ApplicationDbContext _context;
        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepository _departmentRepository;
        private ISalaryRepository _salaryRepository;
        private ILeaveApplicationRepository _leaveRepository;
        private IEmployeeWisePresentAbsentRepository _employeeWisePresentAbsentRepository;
        
        public IEmployeeRepository EmployeeRepository =>
            _employeeRepository ?? new EmployeeRepository(_context);

        public IDepartmentRepository DepartmentRepository =>
           _departmentRepository ?? new DepartmentRepository(_context);

        public ISalaryRepository SalaryRepository =>
        _salaryRepository ?? new SalaryRepository(_context);

        public ILeaveApplicationRepository LeaveApplicationRepository =>
            _leaveRepository ?? new LeaveApplicationRepository(_context);

        public IEmployeeWisePresentAbsentRepository EmployeeWisePresentAbsentRepository =>
           _employeeWisePresentAbsentRepository ?? new EmployeeWisePresentAbsentRepository(_context);

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
