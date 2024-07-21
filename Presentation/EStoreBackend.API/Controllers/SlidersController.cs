using EStoreBackend.API.Helper;
using EStoreBackend.Application.Features.Commands.Slider.CreateSlider;
using EStoreBackend.Application.Features.Commands.Slider.RemoveSlider;
using EStoreBackend.Application.Features.Commands.Slider.UpdateSlider;
using EStoreBackend.Application.Features.Queries.Slider.GetAllSlider;
using EStoreBackend.Application.Features.Queries.Slider.GetByIdSlider;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CacheHelper _cacheHelper;
        public SlidersController(IMediator mediator, CacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }

        [HttpGet("[action]")]
        [OutputCache(PolicyName = "Cache", Tags = ["Slider"])]
        public async Task<IActionResult> GetAllSliders()
        {
            GetAllSliderQueryResponse response = await _mediator.Send(new GetAllSliderQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdSlider([FromRoute] GetByIdSliderQueryRequest request)
        {
            GetByIdSliderQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSlider([FromBody] CreateSliderCommandRequest request)
        {
            CreateSliderCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Slider");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSlider([FromBody] UpdateSliderCommandRequest request)
        {
            UpdateSliderCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Slider");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveSlider(string Id)
        {
            RemoveSliderCommandRequest request = new RemoveSliderCommandRequest { Id = Id };
            RemoveSliderCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Slider");
            return Ok(response);
        }
    }
}
