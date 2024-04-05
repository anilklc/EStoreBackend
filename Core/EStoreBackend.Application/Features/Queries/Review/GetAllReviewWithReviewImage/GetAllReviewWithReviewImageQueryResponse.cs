using EStoreBackend.Application.DTOs.BrandImage;
using EStoreBackend.Application.DTOs.ReviewImage;

namespace EStoreBackend.Application.Features.Queries.Review.GetAllReviewWithReviewImage
{
    public class GetAllReviewWithReviewImageQueryResponse
    {
        public List<ListReviewWithReviewImage> ReviewWithReviewImages { get; set; }

    }
}