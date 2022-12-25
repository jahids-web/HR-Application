using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1{version:apiVersion}/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("get all data");
        }

        [HttpGet("{department}")]
        public IActionResult GetA(string department)
        {
            return Ok("Get One + designation + data");
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return Ok("insert + department + data");
        }

        [HttpPut("{department}")]
        public IActionResult Update(string department)
        {
            return Ok("Update + department + data ");
        }

        [HttpDelete("{department}")]
        public IActionResult Delete(string department)
        {
            return Ok("delete + department + data");
        }
    }
}
