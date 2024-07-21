using EStoreBackend.API.Helper;
using EStoreBackend.Application.Features.Commands.Brand.CreateBrand;
using EStoreBackend.Application.Features.Commands.Brand.RemoveBrand;
using EStoreBackend.Application.Features.Commands.Brand.UpdateBrand;
using EStoreBackend.Application.Features.Queries.Brand.GetAllBrand;
using EStoreBackend.Application.Features.Queries.Brand.GetAllBrandWithBrandImage;
using EStoreBackend.Application.Features.Queries.Brand.GetByIdBrand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CacheHelper _cacheHelper;

        public BrandsController(IMediator mediator, CacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }

        [HttpGet("[action]")]
        [OutputCache(PolicyName = "Cache", Tags = ["Brand"])]
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

        [HttpGet("[action]")]
        [OutputCache(PolicyName = "Cache", Tags = ["Brand"])]
        public async Task<IActionResult> GetAllBrandWithBrandImage()
        {
            GetAllBrandWithBrandImageQueryResponse response = await _mediator.Send(new GetAllBrandWithBrandImageQueryRequest());
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommandRequest request)
        {
            CreateBrandCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Brand");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommandRequest request)
        {
            UpdateBrandCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Brand");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveBrand(string Id)
        {
            RemoveBrandCommandRequest request = new RemoveBrandCommandRequest { Id = Id };
            RemoveBrandCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Brand");
            return Ok(response);
        }
    }
}
