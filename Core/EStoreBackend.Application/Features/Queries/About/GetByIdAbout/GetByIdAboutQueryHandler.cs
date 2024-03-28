using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.About.GetByIdAbout
{
    public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQueryRequest, GetByIdAboutQueryResponse>
    {
        private readonly IAboutReadRepository _aboutReadRepository;

        public GetByIdAboutQueryHandler(IAboutReadRepository aboutReadRepository)
        {
            _aboutReadRepository = aboutReadRepository;
        }

        public async Task<GetByIdAboutQueryResponse> Handle(GetByIdAboutQueryRequest request, CancellationToken cancellationToken)
        {
            var about = await _aboutReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                AboutTitle = about.AboutTitle,
                AboutDescription = about.AboutDescription,
                AboutIcon = about.AboutIcon,
            };
        }
    }
}
