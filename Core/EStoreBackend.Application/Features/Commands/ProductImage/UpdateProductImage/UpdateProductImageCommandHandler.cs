using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.ProductImage.UpdateProductImage
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommandRequest, UpdateProductImageCommandResponse>
    {
        private readonly IProductImageReadRepository _productImageReadRepository;
        private readonly IProductImageWriteRepository _productImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public UpdateProductImageCommandHandler(IProductImageReadRepository productImageReadRepository, IProductImageWriteRepository productImageWriteRepository, IFileHelper fileHelper)
        {
            _productImageReadRepository = productImageReadRepository;
            _productImageWriteRepository = productImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<UpdateProductImageCommandResponse> Handle(UpdateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var file = await _productImageReadRepository.GetByIdAsync(request.Id);
            file.ImagePath = _fileHelper.Update(request.formFile, PathConstants.ImagesProductAddPath + file.ImagePath, PathConstants.ImagesProductAddPath);
            await _productImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
