using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.ProductImage.UpdateProductImage
{
    public class UpdateProductImageCommandRequest : IRequest<UpdateProductImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFile formFile { get; set; }
    }
}