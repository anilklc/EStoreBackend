using MediatR;

namespace EStoreBackend.Application.Features.Commands.Footer.CreateFooter
{
    public class CreateFooterCommandRequest : IRequest<CreateFooterCommandResponse>
    {
        public string FooterAddress { get; set; }
        public string FooterPhone { get; set; }
        public string FooterEmail { get; set; }
    }
}