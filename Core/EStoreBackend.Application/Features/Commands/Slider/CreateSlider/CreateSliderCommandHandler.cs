using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Slider.CreateSlider
{
    public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommandRequest, CreateSliderCommandResponse>
    {
        private readonly ISliderWriteRepository _sliderWriteRepository;

        public CreateSliderCommandHandler(ISliderWriteRepository sliderWriteRepository)
        {
            _sliderWriteRepository = sliderWriteRepository;
        }

        public async Task<CreateSliderCommandResponse> Handle(CreateSliderCommandRequest request, CancellationToken cancellationToken)
        {
            await _sliderWriteRepository.AddAsync(new()
            {
                SliderTitle = request.SliderTitle,
                SliderSubtitle = request.SliderSubtitle,
                SliderTargetUrl = request.SliderTargetUrl,
                SliderActive = request.SliderActive,
            });
            await _sliderWriteRepository.SaveAsync();
            return new();
        }
    }
}
