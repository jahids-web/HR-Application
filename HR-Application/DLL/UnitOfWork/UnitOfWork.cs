﻿using DLL.DataContext;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.UnitOfWork
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
        
        public IEmployeeRepository EmployeeRepository =>
            _employeeRepository ?? new EmployeeRepository(_context);

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
