using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Interfaces.Query;
using Application.Services.DeliveryTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DeliveryTypeController : ControllerBase
    {
        private readonly GetAllDeliveryTypesService _getAll;
        public DeliveryTypeController(GetAllDeliveryTypesService getAll)
        {
            _getAll = getAll;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<DeliveryTypeDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DeliveryTypeDto>>> GetAll()
        {
            return Ok(await _getAll.GetAllAsync());
        }
    }
}