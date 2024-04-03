using EStoreBackend.Application.Features.Commands.Feature.CreateFeature;
using EStoreBackend.Application.Features.Commands.Feature.RemoveFeature;
using EStoreBackend.Application.Features.Commands.Feature.UpdateFeature;
using EStoreBackend.Application.Features.Queries.Feature.GetAllFeature;
using EStoreBackend.Application.Features.Queries.Feature.GetByIdFeature;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureCommandRequest request)
        {
            CreateFeatureCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFeature([FromBody] UpdateFeatureCommandRequest request)
        {
            UpdateFeatureCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveFeature(string Id)
        {
            RemoveFeatureCommandRequest request = new RemoveFeatureCommandRequest { Id = Id };
            RemoveFeatureCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
