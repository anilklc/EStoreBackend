using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class ProductWriteepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
