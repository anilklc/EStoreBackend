using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.Review.UpdateReview
{
    public class UpdateReviewCommandRequest : IRequest<UpdateReviewCommandResponse>
    {
        public string Id { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewComment { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}