using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Features.Commands.BrandImage.RemoveBrandImage;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Brand.RemoveBrand
{
    public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommandRequest, RemoveBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IBrandImageWriteRepository _brandImageWriteRepository;
        private readonly IBrandImageReadRepository _brandImageReadRepository;
        private readonly IFileHelper _fileHelper;

        public RemoveBrandCommandHandler(IBrandWriteRepository brandWriteRepository, IBrandImageWriteRepository brandImageWriteRepository, IBrandImageReadRepository brandImageReadRepository, IFileHelper fileHelper)
        {
            _brandWriteRepository = brandWriteRepository;
            _brandImageWriteRepository = brandImageWriteRepository;
            _brandImageReadRepository = brandImageReadRepository;
            _fileHelper = fileHelper;
        }

        public async Task<RemoveBrandCommandResponse> Handle(RemoveBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _brandWriteRepository.RemoveAsync(request.Id);
            var images =  _brandImageReadRepository.GetWhere(b=>b.BrandId == Guid.Parse(request.Id)).ToList();
            foreach (var item in images)
            {
                _fileHelper.Delete(PathConstants.ImagesBrandAddPath + item.ImagePath);
                await _brandImageWriteRepository.RemoveAsync(item.Id.ToString());
            }
            await _brandImageWriteRepository.SaveAsync();
            await _brandWriteRepository.SaveAsync();
            return new();
        }
    }
}
