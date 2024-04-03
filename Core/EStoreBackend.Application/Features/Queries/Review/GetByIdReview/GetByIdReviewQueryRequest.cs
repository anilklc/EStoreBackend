using MediatR;

namespace EStoreBackend.Application.Features.Queries.Review.GetByIdReview
{
    public class GetByIdReviewQueryRequest : IRequest<GetByIdReviewQueryResponse>
    {
        public string Id { get; set; }    
    }
}