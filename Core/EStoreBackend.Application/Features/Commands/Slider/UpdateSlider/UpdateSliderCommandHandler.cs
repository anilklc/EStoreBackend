using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Slider.UpdateSlider
{
    public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommandRequest, UpdateSliderCommandResponse>
    {
        private readonly ISliderReadRepository _sliderReadRepository;
        private readonly ISliderWriteRepository _sliderWriteRepository;

        public UpdateSliderCommandHandler(ISliderReadRepository sliderReadRepository, ISliderWriteRepository sliderWriteRepository)
        {
            _sliderReadRepository = sliderReadRepository;
            _sliderWriteRepository = sliderWriteRepository;
        }

        public async Task<UpdateSliderCommandResponse> Handle(UpdateSliderCommandRequest request, CancellationToken cancellationToken)
        {
            var slider = await _sliderReadRepository.GetByIdAsync(request.Id);
            slider.SliderTitle = request.SliderTitle;
            slider.SliderSubtitle = request.SliderSubtitle;
            slider.SliderTargetUrl = request.SliderTargetUrl;
            slider.SliderActive = request.SliderActive;
            await _sliderWriteRepository.SaveAsync();
            return new();
        }
    }
}
