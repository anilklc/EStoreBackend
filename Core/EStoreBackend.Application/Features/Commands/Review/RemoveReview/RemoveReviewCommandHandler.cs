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
        private readonly IReviewReadRepository _reviewReadRepository;
        private readonly IFileHelper _fileHelper;

        public RemoveReviewCommandHandler(IReviewWriteRepository reviewWriteRepository, IReviewReadRepository reviewReadRepository, IFileHelper fileHelper)
        {
            _reviewWriteRepository = reviewWriteRepository;
            _reviewReadRepository = reviewReadRepository;
            _fileHelper = fileHelper;
        }

        public async Task<RemoveReviewCommandResponse> Handle(RemoveReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _reviewReadRepository.GetByIdAsync(request.Id);
            _fileHelper.Delete(Path.Combine(PathConstants.ImagesReviewAddPath, review.ReviewImagePath));
            await _reviewWriteRepository.RemoveAsync(request.Id);
            await _reviewWriteRepository.SaveAsync();
            return new();
        }
    }
}
