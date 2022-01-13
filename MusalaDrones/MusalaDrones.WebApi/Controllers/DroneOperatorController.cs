using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaDrones.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneOperatorController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Test works.";
        }
    }
}
