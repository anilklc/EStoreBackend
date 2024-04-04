using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Footer.UpdateFooter
{
    public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommandRequest, UpdateFooterCommandResponse>
    {
        private readonly IFooterReadRepository _footerReadRepository;
        private readonly IFooterWriteRepository _footerWriteRepository;
        public UpdateFooterCommandHandler(IFooterReadRepository footerReadRepository, IFooterWriteRepository footerWriteRepository)
        {
            _footerReadRepository = footerReadRepository;
            _footerWriteRepository = footerWriteRepository;
        }

        public async Task<UpdateFooterCommandResponse> Handle(UpdateFooterCommandRequest request, CancellationToken cancellationToken)
        {
            var footer = await _footerReadRepository.GetByIdAsync(request.Id);
            footer.FooterAddress = request.FooterAddress;
            footer.FooterPhone = request.FooterPhone;
            footer.FooterEmail = request.FooterEmail;
            await _footerWriteRepository.SaveAsync();
            return new();
        }
    }
}
