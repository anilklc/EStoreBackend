using EStoreBackend.Application.Features.Commands.Stock.CreateStock;
using EStoreBackend.Application.Features.Commands.Stock.RemoveStock;
using EStoreBackend.Application.Features.Commands.Stock.UpdateStock;
using EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageByBrandId;
using EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageById;
using EStoreBackend.Application.Features.Queries.Stock.GetAllStockByIdProduct;
using EStoreBackend.Application.Features.Queries.Stock.GetStockById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StocksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{ProductId}")]
        public async Task<IActionResult> GetAllStockByProductId([FromRoute] GetAllStockByIdProductQueryRequest request)
        {
            GetAllStockByIdProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetStockById([FromRoute] GetStockByIdQueryRequest request)
        {
            GetStockByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockCommandRequest request)
        {
            CreateStockCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStockCommandRequest request)
        {
            UpdateStockCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveStock(string Id)
        {
            RemoveStockCommandRequest request = new RemoveStockCommandRequest { Id = Id };
            RemoveStockCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
