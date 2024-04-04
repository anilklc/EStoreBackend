using MediatR;

namespace EStoreBackend.Application.Features.Commands.Slider.RemoveSlider
{
    public class RemoveSliderCommandRequest : IRequest<RemoveSliderCommandResponse>
    {
        public string Id { get; set; }
    }
}