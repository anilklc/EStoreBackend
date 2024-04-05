using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Review.GetAllReview
{
    public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQueryRequest, GetAllReviewQueryResponse>
    {
        private readonly IReviewReadRepository _reviewReadRepository;

        public GetAllReviewQueryHandler(IReviewReadRepository reviewReadRepository)
        {
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<GetAllReviewQueryResponse> Handle(GetAllReviewQueryRequest request, CancellationToken cancellationToken)
        {
            var reviews = _reviewReadRepository.GetAll().ToList();
            return new()
            {
                Reviews = reviews,
            };
        }
    }
}
