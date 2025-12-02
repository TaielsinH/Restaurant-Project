using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Dtos.Models.SearchOrderResponses;
using Application.Dtos.Requests;
using Application.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController
    (CreateOrderService create, OrderSearchService search,
    GetOrderService get, UpdateOrderService update, UpdateOrderItemService updateOrderItem) : ControllerBase
    {
        private readonly CreateOrderService _create = create;
        private readonly OrderSearchService _search = search;
        private readonly GetOrderService _get = get;
        private readonly UpdateOrderService _update = update;
        private readonly UpdateOrderItemService _updateOrderItem = updateOrderItem;

        [HttpPost]
        [ProducesResponseType(typeof(CreateOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)] 
        public async Task<ActionResult<CreateOrderResponse>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var response = await _create.CreateAsync(request);
            return CreatedAtAction(
            nameof(CreateOrder),
            new { id = response.OrderNumber },
            response);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<OrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<OrderResponse>>> SearchOrder([FromQuery] OrderSearchRequest request, CancellationToken ct)
        {
            return Ok(await _search.SearchAsync(request, ct));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<OrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderResponse>> GetOrder(string id)
        {
            return Ok(await _get.GetAsync(id));
        }
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(UpdateOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateOrderResponse>> UpdateOrder([FromBody] OrderUpdateRequest request, string id)
        {
            return Ok(await _update.UpdateAsync(request, id));
        }
        [HttpPatch("{id}/item/{itemId}")]
        [ProducesResponseType(typeof(UpdateOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateOrderResponse>> UpdateItemStatus(string id, string itemId, [FromBody] UpdateOrderItemRequest request)
        {
            return Ok(await _updateOrderItem.UpdateItem(id, itemId, request));
        } 
    }
}