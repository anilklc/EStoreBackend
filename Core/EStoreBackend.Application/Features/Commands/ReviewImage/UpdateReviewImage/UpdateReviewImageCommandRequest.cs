using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.ReviewImage.UpdateReviewImage
{
    public class UpdateReviewImageCommandRequest : IRequest<UpdateReviewImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFile formFile { get; set; }
    }
}