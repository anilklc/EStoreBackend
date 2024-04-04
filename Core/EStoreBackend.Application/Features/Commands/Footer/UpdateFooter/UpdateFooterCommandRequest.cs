using MediatR;

namespace EStoreBackend.Application.Features.Commands.Footer.UpdateFooter
{
    public class UpdateFooterCommandRequest : IRequest<UpdateFooterCommandResponse>
    {
        public string Id { get; set; }
        public string FooterAddress { get; set; }
        public string FooterPhone { get; set; }
        public string FooterEmail { get; set; }
    }
}