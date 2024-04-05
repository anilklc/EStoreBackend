using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.SliderImage.UpdateSliderImage
{
    public class UpdateSliderImageCommandRequest : IRequest<UpdateSliderImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFile formFile { get; set; }
    }
}