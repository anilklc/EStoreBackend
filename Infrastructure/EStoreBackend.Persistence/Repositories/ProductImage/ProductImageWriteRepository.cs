using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class ProductImageWriteRepository : WriteRepository<ProductImage>, IProductImageWriteRepository
    {
        public ProductImageWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
