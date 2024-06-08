using MediatR;

namespace EStoreBackend.Application.Features.Commands.Prdouct.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
    }
}