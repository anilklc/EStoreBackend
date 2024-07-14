using EStoreBackend.Application.Features.Commands.Order.CreateOrder;
using EStoreBackend.Application.Features.Commands.Order.UpdateOrderCargo;
using EStoreBackend.Application.Features.Commands.Order.UpdateOrderStatus;
using EStoreBackend.Application.Features.Queries.Order.GetAllOrder;
using EStoreBackend.Application.Features.Queries.Order.GetAllOrderByUserId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{Status}")]
        public async Task<IActionResult> GetAllOrder([FromRoute] GetAllOrderQueryRequest request)
        {
            GetAllOrderQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Username}/{Status}")]
        public async Task<IActionResult> GetAllOrderByUserId([FromRoute] GetAllOrderByUserIdQueryRequest request)
        {
            GetAllOrderByUserIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest request)
        {
            CreateOrderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusCommandRequest request)
        {
            UpdateOrderStatusCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrderCargo([FromBody] UpdateOrderCargoCommandRequest request)
        {
            UpdateOrderCargoCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
