using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.SliderImage.CreateSliderImage
{
    public class CreateSliderImageCommandRequest : IRequest<CreateSliderImageCommandResponse>
    {
        public IFormFile FormFile { get; set; }
        public string SliderId { get; set; }
    }
}