using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStoreBackend.Application.Constants;
using System.Reflection.Metadata.Ecma335;

namespace EStoreBackend.Application.Features.Commands.Review.RemoveReview
{
    public class RemoveReviewCommandHandler : IRequestHandler<RemoveReviewCommandRequest, RemoveReviewCommandResponse>
    {
        private readonly IReviewWriteRepository _reviewWriteRepository;
        private readonly IReviewImageReadRepository _reviewImageReadRepository;
        private readonly IReviewImageWriteRepository _reviewImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public RemoveReviewCommandHandler(IReviewWriteRepository reviewWriteRepository, IReviewImageReadRepository reviewImageReadRepository, IReviewImageWriteRepository reviewImageWriteRepository, IFileHelper fileHelper)
        {
            _reviewWriteRepository = reviewWriteRepository;
            _reviewImageReadRepository = reviewImageReadRepository;
            _reviewImageWriteRepository = reviewImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<RemoveReviewCommandResponse> Handle(RemoveReviewCommandRequest request, CancellationToken cancellationToken)
        {
            await _reviewWriteRepository.RemoveAsync(request.Id);
            var images = _reviewImageReadRepository.GetWhere(r => r.ReviewId == Guid.Parse(request.Id)).ToList();
            foreach (var item in images)
            {
                _fileHelper.Delete(PathConstants.ImagesReviewAddPath + item.ImagePath);
                await _reviewImageWriteRepository.RemoveAsync(item.Id.ToString());
            }
            await _reviewImageWriteRepository.SaveAsync();
            await _reviewWriteRepository.SaveAsync();
            return new();
        }
    }
}
