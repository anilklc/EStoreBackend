using EStoreBackend.Application.Features.Commands.Brand.CreateBrand;
using EStoreBackend.Application.Features.Commands.Brand.RemoveBrand;
using EStoreBackend.Application.Features.Commands.Brand.UpdateBrand;
using EStoreBackend.Application.Features.Queries.Brand.GetAllBrand;
using EStoreBackend.Application.Features.Queries.Brand.GetByIdBrand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBrands()
        {
            GetAllBrandQueryResponse response = await _mediator.Send(new GetAllBrandQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdBrand([FromRoute] GetByIdBrandQueryRequest request)
        {
            GetByIdBrandQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommandRequest request)
        {
            CreateBrandCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommandRequest request)
        {
            UpdateBrandCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveBrand(string Id)
        {
            RemoveBrandCommandRequest request = new RemoveBrandCommandRequest { Id = Id };
            RemoveBrandCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
