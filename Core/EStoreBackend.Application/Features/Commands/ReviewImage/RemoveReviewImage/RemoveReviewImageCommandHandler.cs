using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStoreBackend.Application.Constants;

namespace EStoreBackend.Application.Features.Commands.ReviewImage.RemoveReviewImage
{
    public class RemoveReviewImageCommandHandler : IRequestHandler<RemoveReviewImageCommandRequest, RemoveReviewImageCommandResponse>
    {
        private readonly IReviewImageReadRepository _reviewImageReadRepository;
        private readonly IReviewImageWriteRepository _reviewImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public RemoveReviewImageCommandHandler(IReviewImageReadRepository reviewImageReadRepository, IReviewImageWriteRepository reviewImageWriteRepository, IFileHelper fileHelper)
        {
            _reviewImageReadRepository = reviewImageReadRepository;
            _reviewImageWriteRepository = reviewImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<RemoveReviewImageCommandResponse> Handle(RemoveReviewImageCommandRequest request, CancellationToken cancellationToken)
        {
            var file = await _reviewImageReadRepository.GetByIdAsync(request.Id);
            _fileHelper.Delete(PathConstants.ImagesReviewAddPath + file.ImagePath);
            await _reviewImageWriteRepository.RemoveAsync(request.Id);
            await _reviewImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
