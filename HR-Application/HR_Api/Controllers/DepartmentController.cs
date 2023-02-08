using BLL.Services;
using BLL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{

    public class DepartmentController : MainController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService employeeService)
        {
            _departmentService = employeeService;
        }

        

      

      

       

       
    }
}
