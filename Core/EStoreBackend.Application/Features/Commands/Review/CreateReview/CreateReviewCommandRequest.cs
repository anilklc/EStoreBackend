using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.Review.CreateReview
{
    public class CreateReviewCommandRequest : IRequest<CreateReviewCommandResponse>
    {
        public string ReviewerName { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewComment { get; set; }
    }
}