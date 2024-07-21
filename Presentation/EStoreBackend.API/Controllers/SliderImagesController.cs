using EStoreBackend.Application.Features.Commands.SliderImage.CreateSliderImage;
using EStoreBackend.Application.Features.Commands.SliderImage.RemoveSliderImage;
using EStoreBackend.Application.Features.Commands.SliderImage.UpdateSliderImage;
using EStoreBackend.Application.Features.Queries.Slider.GetAllActiveSliderWithSliderImage;
using EStoreBackend.Application.Features.Queries.SliderImage.GetSliderImageById;
using EStoreBackend.Application.Features.Queries.SliderImage.GetSliderImageBySliderId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SliderImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{SliderId}")]
        public async Task<IActionResult> GetSliderImageBySliderId([FromRoute] GetSliderImageBySliderIdQueryRequest request)
        {
            GetSliderImageBySliderIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetSliderImageById([FromRoute] GetSliderImageByIdQueryRequest request)
        {
            GetSliderImageByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllActiveSliderWithSliderImage()
        {
            GetAllActiveSliderWithSliderImageQueryResponse response = await _mediator.Send(new GetAllActiveSliderWithSliderImageQueryRequest());
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSliderImage(IFormFile formFile, string SliderId)
        {
            CreateSliderImageCommandRequest request = new() { FormFile = formFile, SliderId = SliderId };
            CreateSliderImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSliderImage(IFormFile formFile, string id)
        {
            UpdateSliderImageCommandRequest request = new() { formFile = formFile, Id = id };
            UpdateSliderImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveSliderImage(string Id)
        {
            RemoveSliderImageCommandRequest request = new RemoveSliderImageCommandRequest { Id = Id };
            RemoveSliderImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
