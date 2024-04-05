using MediatR;

namespace EStoreBackend.Application.Features.Commands.SliderImage.RemoveSliderImage
{
    public class RemoveSliderImageCommandRequest : IRequest<RemoveSliderImageCommandResponse>
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
    }
}