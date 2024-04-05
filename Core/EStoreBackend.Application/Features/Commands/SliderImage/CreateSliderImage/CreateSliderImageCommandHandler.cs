using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.SliderImage.CreateSliderImage
{
    public class CreateSliderImageCommandHandler : IRequestHandler<CreateSliderImageCommandRequest, CreateSliderImageCommandResponse>
    {
        private readonly ISliderImageWriteRepository _sliderImageWriteRepository;
        private readonly IFileHelper _fileHelper;
        public CreateSliderImageCommandHandler(ISliderImageWriteRepository sliderImageWriteRepository, IFileHelper fileHelper)
        {
            _sliderImageWriteRepository = sliderImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<CreateSliderImageCommandResponse> Handle(CreateSliderImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _sliderImageWriteRepository.AddAsync(new()
            {
                ImagePath = _fileHelper.Upload(request.FormFile, PathConstants.ImagesSliderAddPath),
                SliderId = Guid.Parse(request.SliderId),
            });
            await _sliderImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
