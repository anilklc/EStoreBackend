using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.ReviewImage.CreateReviewImage
{
    public class CreateReviewImageCommandRequest : IRequest<CreateReviewImageCommandResponse>
    {
        public IFormFile FormFile { get; set; }
        public string ReviewId { get; set; }
    }
}