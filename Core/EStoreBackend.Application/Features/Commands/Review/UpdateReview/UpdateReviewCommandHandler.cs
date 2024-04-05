using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EStoreBackend.Application.Constants;

namespace EStoreBackend.Application.Features.Commands.Review.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommandRequest, UpdateReviewCommandResponse>
    {
        private readonly IReviewWriteRepository _reviewWriteRepository;
        private readonly IReviewReadRepository _reviewReadRepository;

        public UpdateReviewCommandHandler(IReviewWriteRepository reviewWriteRepository, IReviewReadRepository reviewReadRepository)
        {
            _reviewWriteRepository = reviewWriteRepository;
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<UpdateReviewCommandResponse> Handle(UpdateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _reviewReadRepository.GetByIdAsync(request.Id);
            review.ReviewerName = request.ReviewerName;
            review.ReviewComment = request.ReviewComment;
            review.ReviewTitle = request.ReviewTitle;
            await _reviewWriteRepository.SaveAsync();
            return new();
        }
    }
}
