using EStoreBackend.Application.Features.Queries.Order.GetAllOrderByUserId;
using EStoreBackend.Application.Features.Queries.OrderDetail.GetAllOrderDetailByOrderId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "All")]
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetAllOrderByOrderId([FromRoute] GetAllOrderDetailByOrderIdQueryRequest request)
        {
            GetAllOrderDetailByOrderIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
