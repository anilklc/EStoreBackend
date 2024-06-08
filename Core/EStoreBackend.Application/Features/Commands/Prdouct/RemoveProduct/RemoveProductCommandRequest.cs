using MediatR;

namespace EStoreBackend.Application.Features.Commands.Prdouct.RemoveProduct
{
    public class RemoveProductCommandRequest : IRequest<RemoveProductCommandResponse>
    {
        public string Id { get; set; }
    }
}