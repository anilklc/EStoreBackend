using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.ProductImage.CreateProductImage
{
    public class CreateProductImageCommandRequest : IRequest<CreateProductImageCommandResponse>
    {
        public IFormFile FormFile { get; set; }
        public string ProductId { get; set; }
    }
}