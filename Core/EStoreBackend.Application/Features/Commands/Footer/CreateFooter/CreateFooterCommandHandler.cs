using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Footer.CreateFooter
{
    public class CreateFooterCommandHandler : IRequestHandler<CreateFooterCommandRequest, CreateFooterCommandResponse>
    {
        private readonly IFooterWriteRepository _footerWriteRepository;

        public CreateFooterCommandHandler(IFooterWriteRepository footerWriteRepository)
        {
            _footerWriteRepository = footerWriteRepository;
        }

        public async Task<CreateFooterCommandResponse> Handle(CreateFooterCommandRequest request, CancellationToken cancellationToken)
        {
            await _footerWriteRepository.AddAsync(new()
            {
                FooterAddress = request.FooterAddress,
                FooterEmail = request.FooterEmail,
                FooterPhone = request.FooterPhone,
            });
            await _footerWriteRepository.SaveAsync();
            return new();
        }
    }
}
