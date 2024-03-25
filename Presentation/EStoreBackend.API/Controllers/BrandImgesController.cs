using EStoreBackend.Application.Features.Commands.BrandImage.CreateBrandImage;
using EStoreBackend.Application.Features.Commands.BrandImage.RemoveBrandImage;
using EStoreBackend.Application.Features.Commands.BrandImage.UpdateBrandImage;
using EStoreBackend.Application.Features.Commands.Policy.RemovePolicy;
using EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageByBrandId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandImgesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandImgesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{BrandId}")]
        public async Task<IActionResult> GetBrandImageByBrandId([FromRoute] GetBrandImageByBrandIdQueryRequest request)
        {
            GetBrandImageByBrandIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBrandImage([FromForm] CreateBrandImageCommandRequest request)
        {
            CreateBrandImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBrandImage([FromForm] UpdateBrandImageCommandRequest request)
        {
            UpdateBrandImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveBrandImage(string Id)
        {
            RemoveBrandImageCommandRequest request = new RemoveBrandImageCommandRequest { Id = Id };
            RemoveBrandImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
