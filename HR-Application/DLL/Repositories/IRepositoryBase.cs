using DLL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IRepositoryBase <T> where T : class
    {
        IQueryable<T> QueryAll (Expression<Func<T, bool>> expression = null);
        Task<List<T>> GetList(Expression<Func<T, bool>> expression = null);
        Task CreateAsync(T entry);
        Task<T> FindSingLeAsync(Expression<Func<T, bool>> exception);
        void Update(T entry);
        void Delete(T entry);
        Task<bool> SaveCompletedAsync();
    }

    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;    
        }
        public IQueryable<T> QueryAll(Expression<Func<T, bool>> expression = null)
        {
            return expression != null ? _context.Set<T>().AsQueryable().Where(expression).AsNoTracking() :
                _context.Set<T>().AsQueryable().AsNoTracking();
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> expression = null)
        {
            return  expression != null ? await _context.Set<T>().AsQueryable().Where(expression).AsNoTracking().ToListAsync() :
               await _context.Set<T>().AsQueryable().AsNoTracking().ToListAsync();
        }

        public async Task CreateAsync(T entry)
        {
            await _context.Set<T>().AddAsync(entry);
        }
        public async Task<T> FindSingLeAsync(Expression<Func<T, bool>> exception)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(exception);
        }
        public void Update(T entry)
        {
            _context.Set<T>().Update(entry);
        }
        public void Delete(T entry)
        {
           _context.Set<T>().Remove(entry);
        }

        public async Task<bool> SaveCompletedAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
