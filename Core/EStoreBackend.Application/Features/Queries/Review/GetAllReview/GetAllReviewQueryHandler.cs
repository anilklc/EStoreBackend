using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Review.GetAllReview
{
    public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQueryRequest, GetAllReviewQueryResponse>
    {
        private readonly IReviewReadRepository _reviewReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllReviewQueryHandler(IReviewReadRepository reviewReadRepository, IHttpContextAccessor contextAccessor)
        {
            _reviewReadRepository = reviewReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllReviewQueryResponse> Handle(GetAllReviewQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var reviews = _reviewReadRepository.GetAll().ToList();
            foreach ( var review in reviews )
            {
                if (!string.IsNullOrEmpty(review.ReviewImagePath))
                {
                    review.ReviewImagePath = $"{baseUrl}/{PathConstants.ImagesReviewPath}{review.ReviewImagePath}";
                }
            }
            return new()
            {
                Reviews = reviews,
            };
        }
    }
}
