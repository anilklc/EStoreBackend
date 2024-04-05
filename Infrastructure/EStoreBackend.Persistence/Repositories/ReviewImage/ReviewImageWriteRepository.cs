using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class ReviewImageWriteRepository : WriteRepository<ReviewImage>, IReviewImageWriteRepository
    {
        public ReviewImageWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
