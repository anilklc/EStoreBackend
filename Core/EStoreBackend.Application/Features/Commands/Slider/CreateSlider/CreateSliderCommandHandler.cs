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
        private readonly IFileHelper _fileHelper;

        public CreateSliderCommandHandler(ISliderWriteRepository sliderWriteRepository, IFileHelper fileHelper)
        {
            _sliderWriteRepository = sliderWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<CreateSliderCommandResponse> Handle(CreateSliderCommandRequest request, CancellationToken cancellationToken)
        {
            await _sliderWriteRepository.AddAsync(new()
            {
                SliderTitle = request.SliderTitle,
                SliderSubtitle = request.SliderSubtitle,
                SliderImagePath = _fileHelper.Upload(request.FormFile, PathConstants.ImagesReviewAddPath),
                SliderTargetUrl = request.SliderTargetUrl,
                SliderActive = request.SliderActive,
            });
            await _sliderWriteRepository.SaveAsync();
            return new();
        }
    }
}
