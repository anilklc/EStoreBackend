using EStoreBackend.Application.Features.Commands.Review.CreateReview;
using EStoreBackend.Application.Features.Commands.Review.RemoveReview;
using EStoreBackend.Application.Features.Commands.Review.UpdateReview;
using EStoreBackend.Application.Features.Queries.Review.GetAllReview;
using EStoreBackend.Application.Features.Queries.Review.GetAllReviewWithReviewImage;
using EStoreBackend.Application.Features.Queries.Review.GetByIdReview;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllReviews()
        {
            GetAllReviewQueryResponse response = await _mediator.Send(new GetAllReviewQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdReview([FromRoute] GetByIdReviewQueryRequest request)
        {
            GetByIdReviewQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllReviewWithReviewImage()
        {
            GetAllReviewWithReviewImageQueryResponse response = await _mediator.Send(new GetAllReviewWithReviewImageQueryRequest());
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommandRequest request)
        {
            CreateReviewCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewCommandRequest request)
        {
            UpdateReviewCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveReview(string Id)
        {
            RemoveReviewCommandRequest request = new RemoveReviewCommandRequest { Id = Id };
            RemoveReviewCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
