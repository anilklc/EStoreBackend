using EStoreBackend.Application.Features.Commands.BrandImage.CreateBrandImage;
using EStoreBackend.Application.Features.Commands.BrandImage.RemoveBrandImage;
using EStoreBackend.Application.Features.Commands.BrandImage.UpdateBrandImage;
using EStoreBackend.Application.Features.Commands.Policy.RemovePolicy;
using EStoreBackend.Application.Features.Queries.Brand.GetByIdBrand;
using EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageByBrandId;
using EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{BrandId}")]
        public async Task<IActionResult> GetBrandImageByBrandId([FromRoute] GetBrandImageByBrandIdQueryRequest request)
        {
            GetBrandImageByBrandIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetBrandImageById([FromRoute] GetBrandImageByIdQueryRequest request)
        {
            GetBrandImageByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBrandImage(IFormFile formFile,string brandId)
        {   
            CreateBrandImageCommandRequest request =new(){ FormFile=formFile,BrandId =brandId};
             CreateBrandImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBrandImage(IFormFile formFile, string id)
        {
            UpdateBrandImageCommandRequest request = new() { formFile = formFile, Id = id };
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
