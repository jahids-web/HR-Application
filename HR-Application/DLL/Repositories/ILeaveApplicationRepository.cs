using DLL.DataContext;
using DLL.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface ILeaveApplicationRepository : IRepositoryBase<LeaveApplication>
    {

    }

    public class LeaveApplicationRepository : RepositoryBase<LeaveApplication>, ILeaveApplicationRepository
    {
        public LeaveApplicationRepository(ApplicationDbContext context) : base(context) 
        { 
        
        } 
    }
}
