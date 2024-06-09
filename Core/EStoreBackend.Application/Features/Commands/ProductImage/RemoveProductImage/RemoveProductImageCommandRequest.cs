using MediatR;

namespace EStoreBackend.Application.Features.Commands.ProductImage.RemoveProductImage
{
    public class RemoveProductImageCommandRequest : IRequest<RemoveProductImageCommandResponse>
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
    }
}