using EStoreBackend.API.Helper;
using EStoreBackend.Application.Features.Commands.Feature.CreateFeature;
using EStoreBackend.Application.Features.Commands.Feature.RemoveFeature;
using EStoreBackend.Application.Features.Commands.Feature.UpdateFeature;
using EStoreBackend.Application.Features.Queries.Feature.GetAllFeature;
using EStoreBackend.Application.Features.Queries.Feature.GetByIdFeature;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CacheHelper _cacheHelper;

        public FeaturesController(IMediator mediator, CacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }

        [HttpGet("[action]")]
        [OutputCache(PolicyName = "Cache", Tags = ["Feature"])]
        public async Task<IActionResult> GetAllFeatures()
        {
            GetAllFeatureQueryResponse response = await _mediator.Send(new GetAllFeatureQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdFeature([FromRoute] GetByIdFeatureQueryRequest request)
        {
            GetByIdFeatureQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureCommandRequest request)
        {
            CreateFeatureCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Feature");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFeature([FromBody] UpdateFeatureCommandRequest request)
        {
            UpdateFeatureCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Feature");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveFeature(string Id)
        {
            RemoveFeatureCommandRequest request = new RemoveFeatureCommandRequest { Id = Id };
            RemoveFeatureCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Feature");
            return Ok(response);
        }
    }
}
