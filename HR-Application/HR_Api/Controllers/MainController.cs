﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Api.Controllers
{
    [ApiController]
    [Route("api/v1{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MainController : ControllerBase
    {
    }
}
