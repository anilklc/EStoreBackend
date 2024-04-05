using MediatR;

namespace EStoreBackend.Application.Features.Queries.ReviewImage.GetReviewImageById
{
    public class GetReviewImageByIdQueryRequest : IRequest<GetReviewImageByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}