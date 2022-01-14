using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusalaDrones.Business.Services;
using MusalaDrones.Core.Exceptions;
using MusalaDrones.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusalaDrones.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneOperatorController : ControllerBase
    {
        #region Declarations

        private readonly IDroneOperatorService service;

        #endregion Declarations

        #region Constructors

        public DroneOperatorController(IDroneOperatorService operatorService)
        {
            service = operatorService;
        }

        #endregion Constructors

        #region Methods

        [HttpPost("drone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterDroneAsync([FromBody] Drone drone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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

        [HttpPost("drone/{id}/load")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoadDroneAsync(int id, [FromBody] List<int> medicationItemIds)
        {
            try
            {
                await service.LoadDroneAsync(id, medicationItemIds);
                return Ok();
            }
            catch (DroneNotFoundException)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (LowBatteryLevelException)
            {
                return new StatusCodeResult(StatusCodes.Status412PreconditionFailed);
            }
            catch (MedicationItemNotFoundException)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (DroneOverloadException)
            {
                return new StatusCodeResult(StatusCodes.Status412PreconditionFailed);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("drone/{id}/medicationitems")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicationItem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLoadedMedicationItemsAsync(int id)
        {
            try
            {
                return Ok(await service.GetLoadedMedicationItemsAsync(id));
            }
            catch (DroneNotFoundException)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("drone/available")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Drone>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAvailableDrones()
        {
            try
            {
                return Ok(await service.GetAvailableDronesAsync());
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("drone/{id}/batterylevel")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBatteryLevelAsync(int id)
        {
            try
            {
                return Ok(await service.GetBatteryLevelAsync(id));
            }
            catch (DroneNotFoundException)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        #endregion Methods
    }
}