using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.BrandImage;
using EStoreBackend.Application.DTOs.ReviewImage;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Review.GetAllReviewWithReviewImage
{
    public class GetAllReviewWithReviewImageQueryHandler : IRequestHandler<GetAllReviewWithReviewImageQueryRequest, GetAllReviewWithReviewImageQueryResponse>
    {
        private readonly IReviewReadRepository _reviewReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllReviewWithReviewImageQueryHandler(IReviewReadRepository reviewReadRepository, IHttpContextAccessor contextAccessor)
        {
            _reviewReadRepository = reviewReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllReviewWithReviewImageQueryResponse> Handle(GetAllReviewWithReviewImageQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var files = await _reviewReadRepository.GetAll().Include(r => r.ReviewImages).ToListAsync();
            var reviewWithImages = files.SelectMany(r => r.ReviewImages.Select(reviewImage => new ListReviewWithReviewImage
            {
                Id = reviewImage.Id.ToString(),
                ImagePath = $"{baseUrl}/{PathConstants.ImagesReviewPath}{reviewImage.ImagePath}",
                ReviewId = r.Id.ToString(),
                ReviewComment = r.ReviewComment,
                ReviewerName = r.ReviewerName,
                ReviewTitle = r.ReviewTitle,
               
            })).ToList();
            return new()
            {
                ReviewWithReviewImages = reviewWithImages,

            };
        }
    }
}
