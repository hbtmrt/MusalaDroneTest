using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusalaDrones.Business.Services;
using MusalaDrones.Core.Exceptions;
using MusalaDrones.Core.Models;
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
        private readonly IDroneOperatorService service;

        public DroneOperatorController(IDroneOperatorService operatorService)
        {
            service = operatorService;
        }

        [HttpGet]
        public string Get()
        {
            return "Test works.";
        }

        [HttpPost("drone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterDroneAsync([FromBody] Drone drone)
        {
            try
            {
                await service.RegisterDroneAsync(drone);
                return Ok();
            }
            catch (DronesReachedMaxNumberInFleetException)
            {
                return new StatusCodeResult(StatusCodes.Status412PreconditionFailed);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
