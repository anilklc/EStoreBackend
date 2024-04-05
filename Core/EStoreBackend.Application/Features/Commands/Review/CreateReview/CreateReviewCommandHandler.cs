using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Review.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, CreateReviewCommandResponse>
    {
        private readonly IReviewWriteRepository _reviewWriteRepository;

        public CreateReviewCommandHandler(IReviewWriteRepository reviewWriteRepository)
        {
            _reviewWriteRepository = reviewWriteRepository;
        }

        public async Task<CreateReviewCommandResponse> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            await _reviewWriteRepository.AddAsync(new()
            {
                ReviewerName = request.ReviewerName,
                ReviewComment = request.ReviewComment,
                ReviewTitle = request.ReviewTitle,
            }) ;
            await _reviewWriteRepository.SaveAsync();
            return new();
        }
    }
}
