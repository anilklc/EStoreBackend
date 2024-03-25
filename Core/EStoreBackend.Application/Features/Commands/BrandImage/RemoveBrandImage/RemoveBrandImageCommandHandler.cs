using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.BrandImage.RemoveBrandImage
{
    public class RemoveBrandImageCommandHandler : IRequestHandler<RemoveBrandImageCommandRequest, RemoveBrandImageCommandResponse>
    {
        private readonly IBrandImageReadRepository _brandImageReadRepository;
        private readonly IBrandImageWriteRepository _brandImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public RemoveBrandImageCommandHandler(IBrandImageReadRepository brandImageReadRepository, IBrandImageWriteRepository brandImageWriteRepository, IFileHelper fileHelper)
        {
            _brandImageReadRepository = brandImageReadRepository;
            _brandImageWriteRepository = brandImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<RemoveBrandImageCommandResponse> Handle(RemoveBrandImageCommandRequest request, CancellationToken cancellationToken)
        {
            var file = await _brandImageReadRepository.GetByIdAsync(request.Id);
            _fileHelper.Delete(PathConstants.ImagesBrandAddPath + file.ImagePath);
            await _brandImageWriteRepository.RemoveAsync(request.Id);
            await _brandImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
