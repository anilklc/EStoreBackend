using MediatR;

namespace EStoreBackend.Application.Features.Commands.Review.RemoveReview
{
    public class RemoveReviewCommandRequest : IRequest<RemoveReviewCommandResponse>
    {
        public string Id {  get; set; }
    }
}