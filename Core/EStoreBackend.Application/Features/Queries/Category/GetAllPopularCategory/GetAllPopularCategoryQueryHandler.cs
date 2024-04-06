using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Category.GetAllPopularCategory
{
    public class GetAllPopularCategoryQueryHandler : IRequestHandler<GetAllPopularCategoryQueryRequest, GetAllPopularCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllPopularCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetAllPopularCategoryQueryResponse> Handle(GetAllPopularCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryReadRepository.GetAll().OrderBy(c=>c.Id).Take(8).ToList();
            return new()
            {
                Categories = categories,
            };
        }
    }
}
