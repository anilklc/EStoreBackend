using MediatR;

namespace EStoreBackend.Application.Features.Commands.Footer.RemoveFooter
{
    public class RemoveFooterCommandRequest : IRequest<RemoveFooterCommandResponse>
    {
        public string Id { get; set; }
    }
}