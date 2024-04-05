using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.ReviewImage;
using EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageByBrandId;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.ReviewImage.GetReviewImageByReviewId
{
    public class GetReviewImageByReviewIdQueryHandler : IRequestHandler<GetReviewImageByReviewIdQueryRequest, GetReviewImageByReviewIdQueryResponse>
    {
        private readonly IReviewImageReadRepository _reviewImageReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetReviewImageByReviewIdQueryHandler(IReviewImageReadRepository reviewImageReadRepository, IHttpContextAccessor contextAccessor)
        {
            _reviewImageReadRepository = reviewImageReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetReviewImageByReviewIdQueryResponse> Handle(GetReviewImageByReviewIdQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var files = await _reviewImageReadRepository.GetWhere(r => r.ReviewId == Guid.Parse(request.ReviewId)).Include(rv => rv.Review).ToListAsync();
            var reviewImages = files.Select(r => new ListReviewWithReviewImage
            {
                Id = r.Id.ToString(),
                ImagePath = $"{baseUrl}/{PathConstants.ImagesReviewPath}{r.ImagePath}",
                ReviewId = r.Review.Id.ToString(),
                ReviewComment = r.Review.ReviewComment,
                ReviewerName = r.Review.ReviewerName,
                ReviewTitle  = r.Review.ReviewTitle,
            }).ToList();
            return new ()
            {
                ReviewImages = reviewImages,

            };
        }
    }
}
