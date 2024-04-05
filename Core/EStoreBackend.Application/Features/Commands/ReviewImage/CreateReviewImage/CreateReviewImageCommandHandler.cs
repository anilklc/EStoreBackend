using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.ReviewImage.CreateReviewImage
{
    public class CreateReviewImageCommandHandler : IRequestHandler<CreateReviewImageCommandRequest, CreateReviewImageCommandResponse>
    {
        private readonly IReviewImageWriteRepository _reviewImageWriteRepository;
        private readonly IFileHelper _fileHelper;
        public CreateReviewImageCommandHandler(IReviewImageWriteRepository reviewImageWriteRepository, IFileHelper fileHelper)
        {
            _reviewImageWriteRepository = reviewImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<CreateReviewImageCommandResponse> Handle(CreateReviewImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _reviewImageWriteRepository.AddAsync(new()
            {
                ImagePath = _fileHelper.Upload(request.FormFile, PathConstants.ImagesReviewAddPath),
                ReviewId = Guid.Parse(request.ReviewId),
            });
            await _reviewImageWriteRepository.SaveAsync();
            return new();

        }
    }
}
