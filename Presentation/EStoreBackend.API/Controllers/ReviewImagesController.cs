using EStoreBackend.Application.Features.Commands.ReviewImage.CreateReviewImage;
using EStoreBackend.Application.Features.Commands.ReviewImage.RemoveReviewImage;
using EStoreBackend.Application.Features.Commands.ReviewImage.UpdateReviewImage;
using EStoreBackend.Application.Features.Queries.ReviewImage.GetReviewImageById;
using EStoreBackend.Application.Features.Queries.ReviewImage.GetReviewImageByReviewId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

      [HttpGet("[action]/{ReviewId}")]
        public async Task<IActionResult> GetReviewImageByReviewId([FromRoute] GetReviewImageByReviewIdQueryRequest request)
        {
            GetReviewImageByReviewIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetReviewImageById([FromRoute] GetReviewImageByIdQueryRequest request)
        {
            GetReviewImageByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateReviewImage(IFormFile formFile, string ReviewId)
        {
            CreateReviewImageCommandRequest request = new() { FormFile = formFile, ReviewId = ReviewId };
            CreateReviewImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateReviewImage(IFormFile formFile, string id)
        {
            UpdateReviewImageCommandRequest request = new() { formFile = formFile, Id = id };
            UpdateReviewImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveReviewImage(string Id)
        {
            RemoveReviewImageCommandRequest request = new RemoveReviewImageCommandRequest { Id = Id };
            RemoveReviewImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
