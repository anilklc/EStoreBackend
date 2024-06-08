using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Prdouct.UpdateProductCoverImage
{
    public class UpdateProductCoverImageCommandHandler : IRequestHandler<UpdateProductCoverImageCommandRequest, UpdateProductCoverImageCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IFileHelper _fileHelper;
        public UpdateProductCoverImageCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IFileHelper fileHelper)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _fileHelper = fileHelper;
        }

        public async Task<UpdateProductCoverImageCommandResponse> Handle(UpdateProductCoverImageCommandRequest request, CancellationToken cancellationToken)
        {
            var productImage = await _productReadRepository.GetByIdAsync(request.Id);
            productImage.ProductCoverImagePath = _fileHelper.Update(request.formFile, PathConstants.ImagesProductCoverAddPath + productImage.ProductCoverImagePath, PathConstants.ImagesProductCoverAddPath);
            await _productWriteRepository.SaveAsync();
            return new();

        }
    }
}
