using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class StockWriteRepository : WriteRepository<Stock>, IStockWriteRepository
    {
        public StockWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
