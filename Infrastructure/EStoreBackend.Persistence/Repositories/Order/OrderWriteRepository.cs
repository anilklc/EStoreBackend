using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
