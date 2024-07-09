using MediatR;

namespace EStoreBackend.Application.Features.Commands.Address.RemoveAddress
{
    public class RemoveAddressCommandRequest : IRequest<RemoveAddressCommandResponse>
    {
        public string Id { get; set; }
    }
}