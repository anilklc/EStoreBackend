using EStoreBackend.API.Helper;
using EStoreBackend.Application.Features.Commands.Review.CreateReview;
using EStoreBackend.Application.Features.Commands.Review.RemoveReview;
using EStoreBackend.Application.Features.Commands.Review.UpdateReview;
using EStoreBackend.Application.Features.Queries.Review.GetAllReview;
using EStoreBackend.Application.Features.Queries.Review.GetAllReviewWithReviewImage;
using EStoreBackend.Application.Features.Queries.Review.GetByIdReview;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CacheHelper _cacheHelper;
        public ReviewsController(IMediator mediator, CacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }
        [HttpGet("[action]")]
        [OutputCache(PolicyName = "Cache", Tags = ["Review"])]
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
        [OutputCache(PolicyName = "Cache", Tags = ["Review"])]
        public async Task<IActionResult> GetAllReviewWithReviewImage()
        {
            GetAllReviewWithReviewImageQueryResponse response = await _mediator.Send(new GetAllReviewWithReviewImageQueryRequest());
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommandRequest request)
        {
            CreateReviewCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Review");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewCommandRequest request)
        {
            UpdateReviewCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Review");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveReview(string Id)
        {
            RemoveReviewCommandRequest request = new RemoveReviewCommandRequest { Id = Id };
            RemoveReviewCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Review");
            return Ok(response);
        }
    }
}
