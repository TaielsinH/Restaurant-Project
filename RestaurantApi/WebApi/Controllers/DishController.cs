using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Dtos.Requests;
using Application.Interfaces.Command;
using Application.Services.DishServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DishController : ControllerBase
    {
        private readonly CreateDishService _create;
        private readonly UpdateDishService _update;
        private readonly SearchDishService _search;
        private readonly GetDishService _get;
        private readonly DeleteDishService _delete;
        public DishController
        (CreateDishService create, UpdateDishService update, SearchDishService search, GetDishService get, DeleteDishService delete)
        {
            _create = create;
            _update = update;
            _search = search;
            _get = get;
            _delete = delete;
        }
        [HttpPost]
        [ProducesResponseType(typeof(DishResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<DishResponse>> CreateDish([FromBody] CreateDishRequest request, CancellationToken ct)
        {
            var response = await _create.Create(request, ct);
            return CreatedAtAction(
            nameof(CreateDish),
            new { id = response.Id },
            response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DishResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<DishResponse>> UpdateDish(Guid id, [FromBody] UpdateDishRequest request, CancellationToken ct)
        {
            return Ok(await _update.Update(request, id, ct));
        }
        [HttpGet]
        [ProducesResponseType(typeof(DishResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DishResponse>>> SearchDish([FromQuery] DishQueryParameters request, CancellationToken ct)
        {
            return Ok(await _search.Search(request, ct));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DishResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DishResponse>> GetDishByID([FromRoute] string id, CancellationToken ct)
        {
            return Ok(await _get.GetDishAsync(id, ct));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DishResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DishResponse>> DeleteAsync([FromRoute] string id)
        {
            return Ok(await _delete.DeleteAsync(id));
        }
    }
}