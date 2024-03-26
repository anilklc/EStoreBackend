using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.BrandImage.UpdateBrandImage
{
    public class UpdateBrandImageCommandHandler : IRequestHandler<UpdateBrandImageCommandRequest, UpdateBrandImageCommandResponse>
    {
        private readonly IBrandImageReadRepository _brandImageReadRepository;
        private readonly IBrandImageWriteRepository _brandImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public UpdateBrandImageCommandHandler(IBrandImageReadRepository brandImageReadRepository, IBrandImageWriteRepository brandImageWriteRepository, IFileHelper fileHelper)
        {
            _brandImageReadRepository = brandImageReadRepository;
            _brandImageWriteRepository = brandImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<UpdateBrandImageCommandResponse> Handle(UpdateBrandImageCommandRequest request, CancellationToken cancellationToken)
        {
            var file = await _brandImageReadRepository.GetByIdAsync(request.Id);
            file.ImagePath = _fileHelper.Update(request.formFile,PathConstants.ImagesBrandAddPath+file.ImagePath,PathConstants.ImagesBrandAddPath);
            await _brandImageWriteRepository.SaveAsync();
            return new();

        }
    }
}
