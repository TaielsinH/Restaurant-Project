using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Services.StatusServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly GetAllStatusesService _getAll;
        public StatusController(GetAllStatusesService getAll)
        {
            _getAll = getAll;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<StatusDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<StatusDto>>> GetAll()
        {
            return Ok(await _getAll.GetAllAsync());
        }
    }
}