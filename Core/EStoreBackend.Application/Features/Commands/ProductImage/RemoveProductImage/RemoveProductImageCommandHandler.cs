using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.ProductImage.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        private readonly IProductImageReadRepository _productImageReadRepository;
        private readonly IProductImageWriteRepository _productImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public RemoveProductImageCommandHandler(IProductImageReadRepository productImageReadRepository, IProductImageWriteRepository productImageWriteRepository, IFileHelper fileHelper)
        {
            _productImageReadRepository = productImageReadRepository;
            _productImageWriteRepository = productImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var file = await _productImageReadRepository.GetByIdAsync(request.Id);
            _fileHelper.Delete(PathConstants.ImagesProductAddPath + file.ImagePath);
            await _productImageWriteRepository.RemoveAsync(request.Id);
            await _productImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
