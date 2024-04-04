using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStoreBackend.Application.Constants;

namespace EStoreBackend.Application.Features.Commands.Slider.RemoveSlider
{
    public class RemoveSliderCommandHandler : IRequestHandler<RemoveSliderCommandRequest, RemoveSliderCommandResponse>
    {
        private readonly ISliderReadRepository _sliderReadRepository;
        private readonly ISliderWriteRepository _sliderWriteRepository;
        private readonly IFileHelper _fileHelper;

        public RemoveSliderCommandHandler(ISliderReadRepository sliderReadRepository, ISliderWriteRepository sliderWriteRepository, IFileHelper fileHelper)
        {
            _sliderReadRepository = sliderReadRepository;
            _sliderWriteRepository = sliderWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<RemoveSliderCommandResponse> Handle(RemoveSliderCommandRequest request, CancellationToken cancellationToken)
        {
            var slider = await _sliderReadRepository.GetByIdAsync(request.Id);
            _fileHelper.Delete(Path.Combine(PathConstants.ImagesSliderAddPath, slider.SliderImagePath));
            await _sliderWriteRepository.RemoveAsync(request.Id);
            await _sliderWriteRepository.SaveAsync();
            return new();
        }
    }
}
