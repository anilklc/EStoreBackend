﻿using EStoreBackend.Application.Features.Commands.Review.CreateReview;
using EStoreBackend.Application.Features.Commands.Review.RemoveReview;
using EStoreBackend.Application.Features.Commands.Review.UpdateReview;
using EStoreBackend.Application.Features.Queries.Review.GetAllReview;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateReview(CreateReviewCommandRequest request)
        {
            CreateReviewCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommandRequest request)
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