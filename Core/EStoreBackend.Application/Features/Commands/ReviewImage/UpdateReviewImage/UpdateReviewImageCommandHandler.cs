using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.ReviewImage.UpdateReviewImage
{
    public class UpdateReviewImageCommandHandler : IRequestHandler<UpdateReviewImageCommandRequest, UpdateReviewImageCommandResponse>
    {
        private readonly IReviewImageReadRepository _reviewImageReadRepository;
        private readonly IReviewImageWriteRepository _reviewImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public UpdateReviewImageCommandHandler(IReviewImageReadRepository reviewImageReadRepository, IReviewImageWriteRepository reviewImageWriteRepository, IFileHelper fileHelper)
        {
            _reviewImageReadRepository = reviewImageReadRepository;
            _reviewImageWriteRepository = reviewImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<UpdateReviewImageCommandResponse> Handle(UpdateReviewImageCommandRequest request, CancellationToken cancellationToken)
        {
            var file = await _reviewImageReadRepository.GetByIdAsync(request.Id);
            file.ImagePath = _fileHelper.Update(request.formFile, PathConstants.ImagesReviewAddPath + file.ImagePath, PathConstants.ImagesReviewAddPath);
            await _reviewImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
