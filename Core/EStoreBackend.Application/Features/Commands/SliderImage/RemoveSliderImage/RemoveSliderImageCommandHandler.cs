using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStoreBackend.Application.Constants;

namespace EStoreBackend.Application.Features.Commands.SliderImage.RemoveSliderImage
{
    public class RemoveSliderImageCommandHandler : IRequestHandler<RemoveSliderImageCommandRequest, RemoveSliderImageCommandResponse>
    {
        private readonly ISliderImageReadRepository _sliderImageReadRepository;
        private readonly ISliderImageWriteRepository _sliderImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public RemoveSliderImageCommandHandler(ISliderImageReadRepository sliderImageReadRepository, ISliderImageWriteRepository sliderImageWriteRepository, IFileHelper fileHelper)
        {
            _sliderImageReadRepository = sliderImageReadRepository;
            _sliderImageWriteRepository = sliderImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<RemoveSliderImageCommandResponse> Handle(RemoveSliderImageCommandRequest request, CancellationToken cancellationToken)
        {
            var file = await _sliderImageReadRepository.GetByIdAsync(request.Id);
            _fileHelper.Delete(PathConstants.ImagesSliderAddPath + file.ImagePath);
            await _sliderImageWriteRepository.RemoveAsync(request.Id);
            await _sliderImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
