using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Review.GetByIdReview
{
    public class GetByIdReviewQueryHandler : IRequestHandler<GetByIdReviewQueryRequest, GetByIdReviewQueryResponse>
    {
        private readonly IReviewReadRepository _reviewReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetByIdReviewQueryHandler(IReviewReadRepository reviewReadRepository, IHttpContextAccessor contextAccessor)
        {
            _reviewReadRepository = reviewReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetByIdReviewQueryResponse> Handle(GetByIdReviewQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var review = await _reviewReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                ReviewerName = review.ReviewerName,
                ReviewComment = review.ReviewComment,
                ReviewImagePath = $"{baseUrl}/{PathConstants.ImagesReviewPath}{review.ReviewImagePath}",
                ReviewTitle = review.ReviewTitle,
            };
        }
    }
}
