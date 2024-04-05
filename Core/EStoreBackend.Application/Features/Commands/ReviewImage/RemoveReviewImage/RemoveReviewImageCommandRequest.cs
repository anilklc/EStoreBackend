using MediatR;

namespace EStoreBackend.Application.Features.Commands.ReviewImage.RemoveReviewImage
{
    public class RemoveReviewImageCommandRequest : IRequest<RemoveReviewImageCommandResponse>
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
    }
}