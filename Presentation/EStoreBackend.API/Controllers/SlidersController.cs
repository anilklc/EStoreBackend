using EStoreBackend.Application.Features.Commands.Slider.CreateSlider;
using EStoreBackend.Application.Features.Commands.Slider.RemoveSlider;
using EStoreBackend.Application.Features.Commands.Slider.UpdateSlider;
using EStoreBackend.Application.Features.Queries.Slider.GetAllSlider;
using EStoreBackend.Application.Features.Queries.Slider.GetByIdSlider;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SlidersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSlider([FromBody] CreateSliderCommandRequest request)
        {
            CreateSliderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSlider([FromBody] UpdateSliderCommandRequest request)
        {
            UpdateSliderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveSlider(string Id)
        {
            RemoveSliderCommandRequest request = new RemoveSliderCommandRequest { Id = Id };
            RemoveSliderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
