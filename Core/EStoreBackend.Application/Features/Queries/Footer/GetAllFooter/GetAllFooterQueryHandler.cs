using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Footer.GetAllFooter
{
    public class GetAllFooterQueryHandler : IRequestHandler<GetAllFooterQueryRequest, GetAllFooterQueryResponse>
    {
        private readonly IFooterReadRepository _footerReadRepository;

        public GetAllFooterQueryHandler(IFooterReadRepository footerReadRepository)
        {
            _footerReadRepository = footerReadRepository;
        }

        public async Task<GetAllFooterQueryResponse> Handle(GetAllFooterQueryRequest request, CancellationToken cancellationToken)
        {
            var footers = _footerReadRepository.GetAll().ToList();
            return new()
            {
                Footer = footers,
            };
        }
    }
}
