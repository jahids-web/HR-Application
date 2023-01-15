using DLL.EntityModel;
using DLL.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DataContext
{
    public interface IUnitofWork
    {
         DbSet<Department> Department { get; set; }
         DbSet<Employee> Employee { get; set; }
        Task SaveChangesAsync();
    }
}
