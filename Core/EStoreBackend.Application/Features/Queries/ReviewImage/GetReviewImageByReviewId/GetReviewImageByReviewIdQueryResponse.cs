
using EStoreBackend.Application.DTOs.ReviewImage;

namespace EStoreBackend.Application.Features.Queries.ReviewImage.GetReviewImageByReviewId
{
    public class GetReviewImageByReviewIdQueryResponse
    {
        public List<ListReviewWithReviewImage> ReviewImages { get; set; }

    }
}