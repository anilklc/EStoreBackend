using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class BrandImageWriteRepository : WriteRepository<BrandImage>, IBrandImageWriteRepository
    {
        public BrandImageWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
