using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.SliderImage.UpdateSliderImage
{
    public class UpdateSliderImageCommandHandler : IRequestHandler<UpdateSliderImageCommandRequest, UpdateSliderImageCommandResponse>
    {
        private readonly ISliderImageReadRepository _sliderImageReadRepository;
        private readonly ISliderImageWriteRepository _sliderImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public UpdateSliderImageCommandHandler(ISliderImageReadRepository sliderImageReadRepository, ISliderImageWriteRepository sliderImageWriteRepository, IFileHelper fileHelper)
        {
            _sliderImageReadRepository = sliderImageReadRepository;
            _sliderImageWriteRepository = sliderImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<UpdateSliderImageCommandResponse> Handle(UpdateSliderImageCommandRequest request, CancellationToken cancellationToken)
        {
            var file = await _sliderImageReadRepository.GetByIdAsync(request.Id);
            file.ImagePath = _fileHelper.Update(request.formFile, PathConstants.ImagesSliderAddPath + file.ImagePath, PathConstants.ImagesSliderAddPath);
            await _sliderImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
