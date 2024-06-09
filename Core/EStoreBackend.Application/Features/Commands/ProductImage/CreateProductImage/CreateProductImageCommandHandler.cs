using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.ProductImage.CreateProductImage
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommandRequest, CreateProductImageCommandResponse>
    {
        private readonly IProductImageWriteRepository _productImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public CreateProductImageCommandHandler(IProductImageWriteRepository productImageWriteRepository, IFileHelper fileHelper)
        {
            _productImageWriteRepository = productImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<CreateProductImageCommandResponse> Handle(CreateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _productImageWriteRepository.AddAsync(new()
            {
                ImagePath = _fileHelper.Upload(request.FormFile, PathConstants.ImagesProductAddPath),
                ProductId = Guid.Parse(request.ProductId)
            });
            await _productImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
