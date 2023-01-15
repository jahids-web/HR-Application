using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1{version:apiVersion}/[controller]")]
    public class MainApiController : ControllerBase
    {
    }
}
