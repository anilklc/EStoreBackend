using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Footer.GetByIdFooter
{
    public class GetByIdFooterQueryHandler : IRequestHandler<GetByIdFooterQueryRequest, GetByIdFooterQueryRespnose>
    {
        private readonly IFooterReadRepository _footerReadRepository;

        public GetByIdFooterQueryHandler(IFooterReadRepository footerReadRepository)
        {
            _footerReadRepository = footerReadRepository;
        }

        public async Task<GetByIdFooterQueryRespnose> Handle(GetByIdFooterQueryRequest request, CancellationToken cancellationToken)
        {
            var footer = await _footerReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                FooterAddress = footer.FooterAddress,
                FooterEmail = footer.FooterEmail,
                FooterPhone = footer.FooterPhone,
            };
        }
    }
}
