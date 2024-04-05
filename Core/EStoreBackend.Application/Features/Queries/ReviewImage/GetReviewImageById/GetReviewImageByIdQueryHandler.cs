using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.ReviewImage.GetReviewImageById
{
    public class GetReviewImageByIdQueryHandler : IRequestHandler<GetReviewImageByIdQueryRequest, GetReviewImageByIdQueryResponse>
    {
        private readonly IReviewImageReadRepository _reviewImageReadRepository;

        public GetReviewImageByIdQueryHandler(IReviewImageReadRepository reviewImageReadRepository)
        {
            _reviewImageReadRepository = reviewImageReadRepository;
        }

        public async Task<GetReviewImageByIdQueryResponse> Handle(GetReviewImageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var reviewImage = await _reviewImageReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                ImagePath = reviewImage.ImagePath,
                ReviewId = reviewImage.ReviewId.ToString()
            };
        }
    }
}
