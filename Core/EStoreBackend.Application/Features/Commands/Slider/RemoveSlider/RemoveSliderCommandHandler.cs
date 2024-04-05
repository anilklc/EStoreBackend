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
        private readonly ISliderWriteRepository _sliderWriteRepository;
        private readonly ISliderImageReadRepository _sliderImageReadRepository;
        private readonly ISliderImageWriteRepository _sliderImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public RemoveSliderCommandHandler(ISliderWriteRepository sliderWriteRepository, ISliderImageReadRepository sliderImageReadRepository, ISliderImageWriteRepository sliderImageWriteRepository, IFileHelper fileHelper)
        {
            _sliderWriteRepository = sliderWriteRepository;
            _sliderImageReadRepository = sliderImageReadRepository;
            _sliderImageWriteRepository = sliderImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<RemoveSliderCommandResponse> Handle(RemoveSliderCommandRequest request, CancellationToken cancellationToken)
        {
            await _sliderWriteRepository.RemoveAsync(request.Id);
            var images = _sliderImageReadRepository.GetWhere(s => s.SliderId == Guid.Parse(request.Id)).ToList();
            foreach (var item in images)
            {
                _fileHelper.Delete(PathConstants.ImagesSliderAddPath + item.ImagePath);
                await _sliderImageWriteRepository.RemoveAsync(item.Id.ToString());
            }
            await _sliderImageWriteRepository.SaveAsync();
            await _sliderWriteRepository.SaveAsync();
            return new();
        }
    }
}
