using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Prdouct.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IFileHelper _fileHelper;
        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IFileHelper fileHelper = null)
        {
            _productWriteRepository = productWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(new()
            {
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                Price = request.Price,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                StockId = request.StockId,
                ProductCoverImagePath = _fileHelper.Upload(request.FormFile,PathConstants.ImagesProductCoverAddPath),
            });
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
