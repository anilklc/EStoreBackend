using MediatR;

namespace EStoreBackend.Application.Features.Queries.ReviewImage.GetReviewImageByReviewId
{
    public class GetReviewImageByReviewIdQueryRequest : IRequest<GetReviewImageByReviewIdQueryResponse>
    {
        public string ReviewId { get; set; }
    }
}