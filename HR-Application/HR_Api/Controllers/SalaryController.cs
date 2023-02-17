using BLL.Services;
using DLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR_Api.Controllers
{
    public class SalaryController : MainController
    {
        private readonly ISalaryService _salaryRepository;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryRepository = salaryService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Insert(SelaryViewModel )

    }
}
